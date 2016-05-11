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

        //List<Product> CustomersOrder = new List<Product>();

        public static void ListProducts()
        {
            bool stillOrdering = true;
            int i = 0;

            while (stillOrdering)
            {
                Product product = null;
                List<Product> ProductList = GetProducts();
                for (; i < ProductList.Count; i++)
                {
                    Console.WriteLine(
                        (i + 1) + ". " +
                        ProductList[i].Name + ": " +
                        ProductList[i].Description + " " + "$" +
                        ProductList[i].Price);
                }
                Console.WriteLine((i + 1) + ". Return to Main Menu.");

                string chosenProduct = Console.ReadLine(); // user chooses product
                int chosenProductId = int.Parse(chosenProduct);
                if (chosenProductId > 0 && chosenProductId <= ProductList.Count)
                {
                    product = ProductList[chosenProductId - 1]; // [chosenProductId - 1] is giving us the index of the chosen product within the ProductList 
                    Console.WriteLine("You chose " + product.Name + "."); // because the index starts at 0 but we added 1 to be printed on the console
                }                                               
                else if (chosenProductId == ProductList.Count + 1)
                {
                    stillOrdering = false;
                    Console.Clear();
                }

                List<Product> CustomersOrder = new List<Product>();
                CustomersOrder.Add(product);
                i = 0; 
                // when code gets to this point, i = 4 because of for loop
                // we have to set it back to 0 in order for it to be < the # of items in the ProductList (ProductList.Count)




            }

        }
        

    }
}
