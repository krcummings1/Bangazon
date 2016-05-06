using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int IdProductType { get; set; }
        public int Quantity { get; set; }


        public static List<Product> GetProducts()
        {
            //The SQL Connection to my Invoices Database - GETTING DATA FROM TABLE
            SqlConnection sqlConnection = new SqlConnection();
            ConnectionString connectionString = new ConnectionString();
            var dataSource = connectionString.source;
            sqlConnection.ConnectionString = dataSource;

            List<Product> ProductList = new List<Product>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT IdProduct, Name, Description, Price, IdProductType FROM Product";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Product product = new Product();
                    product.IdProduct = dataReader.GetInt32(0);
                    product.Name = dataReader.GetString(1);
                    product.Description = dataReader.GetString(2);
                    product.Price = dataReader.GetFloat(3);
                    product.IdProductType = dataReader.GetInt32(4);

                    ProductList.Add(product);
                }
            }
            sqlConnection.Close();

            return ProductList;

        }



        public static Product ListProducts()
        {
            Product product = null;
            List<Product> ProductList = GetProducts();
            for (int i = 0; i < ProductList.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) + ". " +
                    ProductList[i].Name + ": " +
                    ProductList[i].Description + " " + "$" +
                    ProductList[i].Price);
            }

            string chosenProduct = Console.ReadLine();
            int chosenProductId = int.Parse(chosenProduct);
            if (chosenProductId >= 0 && chosenProductId <= ProductList.Count)
            {
                product = ProductList[chosenProductId - 1];
            }

            Console.WriteLine("You chose " + product.Name + ". Pick another item or return to the main menu.");

            return product; // returns product chosen by user



            List<Product> CustomersOrder = new List<Product>();
            CustomersOrder.Add(product);
            for (int i = 0; i < CustomersOrder.Count; i++)
            {
                Console.WriteLine( // prints all customers from db to console
                    (i + 1) + ". " +
                    CustomersOrder[i].Name);
            }

        }


        //public static List<Product> CustomersOrder()
        //{

        //    List<Product> CustomersOrder = ListProducts();

        //    Product product = ListProducts();

        //    return CustomersOrder;
        //}





    }
}
