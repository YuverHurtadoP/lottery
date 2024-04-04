using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lottery.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> ListInformation();
        void AddInformation(T entity);
        bool Exists(int id);
     

        T FindByProperty(Expression<Func<T, bool>> predicate);
    }
}
