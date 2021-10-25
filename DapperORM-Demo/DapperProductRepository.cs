using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM_Demo
{
    class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void CreateProduct(string name, decimal price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@productName, @productPrice, @productCategoryID);",
            new { productName = name,  productPrice = price, productCategoryID = categoryID});
        }
    }
}
