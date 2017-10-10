using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace RefactorKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var products = GetProducts();

            foreach (var products in products)
            {
                Console.WriteLine("This product is called: " + Product.Name);
            }
        }

        private static IOrderedEnumerable<Product> GetProducts()
        {
            using (var conn =
                new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Products";

                var reader = cmd.ExecuteReader();
                var products = new List<Product>();

                while (reader.Read())
                {
                    var prod = new Product {Name = reader["Name"].ToString()};
                    products.Add(prod);
                }

                Console.WriteLine("Products Loaded!");
                return products;

            }
        }
    }
        
        