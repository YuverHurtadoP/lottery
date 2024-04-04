using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using lottery.Domain.Repository;
using lottery.Models;
using Microsoft.EntityFrameworkCore;


namespace lottery.Persistence
{
    /// <summary>
    /// Este clase implementa la intefaz  IGenericRepository cuyos metos son genericos
    /// </summary>
    public class GenericRepositoryImpl<T> : IGenericRepository<T> where T : class
    {

        private readonly LotteryContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepositoryImpl(LotteryContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        /// <summary>
        /// funcion generica para guardar con ORM la infomacion
        /// </summary>
        public void AddInformation(T entity)
        { 
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
    // Método genérico para buscar una entidad por una propiedad específica y su valor
    public T FindByProperty(Expression<Func<T, bool>> predicate)
    {
      return _dbSet.FirstOrDefault(predicate);
    }
    public bool Exists(int id)
    {
      // Verificar si existe un objeto con el ID proporcionado en la base de datos
      return _dbSet.Find(id) != null;
    }

    /// <summary>
    /// funcion generica para sacar la infomacion
    /// </summary>
    public IEnumerable<T> ListInformation()
        {
            return _dbSet.ToList();
        }
    }
}
