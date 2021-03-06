using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM_Demo
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(string name, decimal price, int categoryID);
    }
}
