using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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
            
        }
        var Conn = new System.Data.SqlClient.SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");

            System.Data.SqlClient.SqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "select * from Products";
            /*
             * cmd.CommandText = "Select * from Invoices";
             */
            System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();

            //TODO: Replace with Dapper
            while (reader.Read())
            {
                var prod = new Product();
                prod.name = reader["Name"].ToString();
                products.Add(prod);
            }
            Conn.Dispose();
            Console.WriteLine("Products Loaded!");
            for (int i =0; i< products.Count; i++)
            {
                Console.WriteLine(products[i].name);
            }
        }
    }
    public class Product
    {
        public string Name { get { return name; } set { name = value; } }
    }
}
