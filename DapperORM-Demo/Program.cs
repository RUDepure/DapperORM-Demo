using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperORM_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            
            IDbConnection conn = new MySqlConnection(connString);
            
            //Implemented Department Section, Exercise 1
            //
            //----------------------------------------------
            var repoDept = new DapperDepartmentRepository(conn);

            Console.WriteLine("Type a new Department name");

            var newDepartment = Console.ReadLine();

            repoDept.InsertDepartment(newDepartment);

            var departments = repoDept.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }

            //Implemented Product Section, Exercise 2
            //
            //----------------------------------------------
            Console.WriteLine("==================================================================");
            var repoProd = new DapperProductRepository(conn);

            Console.WriteLine("Type the values of a new product");
            Console.Write("Type the name:");
            var prodName = Console.ReadLine();

            //Recieves the Product Price
            Console.Write("Type its price:");
            decimal prodPrice = 0;

            //Checks if you are typing a valid decimal value for the Product Price
            var validPrice = Decimal.TryParse(Console.ReadLine(), out prodPrice);
            while (!validPrice)
            {
                Console.WriteLine("Please type a decimal number for the price");
                Console.Write("Type its price:");
                validPrice = Decimal.TryParse(Console.ReadLine(), out prodPrice);
            }

            //Checks if you are typing a valid Interger value for the Cetegory ID
            Console.Write("Type its Category ID:");
            int prodCategoryID = 0;

            var validCategoryID = Int32.TryParse(Console.ReadLine(), out prodCategoryID);
            while (!validCategoryID)
            {
                Console.WriteLine("Please type a decimal number for the price");
                Console.Write("Type its price:");
                validCategoryID = Int32.TryParse(Console.ReadLine(), out prodCategoryID);
            }

            //Catches the exception in case the values are not valid for insertion
            try
            {
                repoProd.CreateProduct(prodName, prodPrice, prodCategoryID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Unable to insert the values: '{prodName}', '{prodPrice}', '{prodCategoryID}'");
            }

            var products = repoProd.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} | {prod.Name} | {prod.Price} | {prod.CategoryID} | {prod.OnSale} | {prod.StockLevel}");
            }

        }
    }
}
