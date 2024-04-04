using lottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery.Domain.Repository
{
    public interface IProductReposity
    {
        void saveProduct(Product product);
    }
}
