using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }


        public void CreateCustomer()
        {
            Customer customer = new Customer();

            Console.WriteLine("Type first and last name then press enter.");
            string[] fullName = Console.ReadLine().Split(' ');
            customer.FirstName = fullName[0];
            customer.LastName = fullName[1];
            Console.WriteLine("You entered " + customer.FirstName + " " + customer.LastName + ". Enter street address");
            customer.StreetAddress = Console.ReadLine();
            Console.WriteLine("Enter city");
            customer.City = Console.ReadLine();
            Console.WriteLine("Enter state abbreviation");
            customer.State = Console.ReadLine();
            Console.WriteLine("Enter postal code");
            customer.PostalCode = Console.ReadLine();
            Console.WriteLine("Enter phone number with no dashes");
            customer.PhoneNumber = Console.ReadLine();

            string command = @"
                    INSERT INTO Customer
                        (FirstName, LastName, StreetAddress, City, State, PostalCode, PhoneNumber)
                    VALUES
                        ('" + customer.FirstName + "', '" + customer.LastName + "', '" + customer.StreetAddress + "', '" + customer.City + "', '" + customer.State + "', '" + customer.PostalCode + "', '" + customer.PhoneNumber + "')";

            System.Data.SqlClient.SqlConnection sqlConnection1 =
            new System.Data.SqlClient.SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\kaylee cummings\\documents\\visual studio 2015\\Projects\\Bangazon\\Bangazon\\Invoices.mdf\";Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = command;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();

            Console.Clear();
        }

        public static List<Customer> GetCustomers()
        {
            //The SQL Connection to my Invoices Database - GETTING DATA FROM TABLE
            SqlConnection sqlConnection = new SqlConnection();
            ConnectionString connectionString = new ConnectionString();
            var dataSource = connectionString.source;
            sqlConnection.ConnectionString = dataSource;

            List<Customer> CustomerList = new List<Customer>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT IdCustomer, FirstName, LastName, StreetAddress, City, State, PostalCode, PhoneNumber FROM Customer";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Customer customer = new Customer();
                    customer.IdCustomer = dataReader.GetInt32(0);
                    customer.FirstName = dataReader.GetString(1);
                    customer.LastName = dataReader.GetString(2);
                    customer.StreetAddress = dataReader.GetString(3);
                    customer.City = dataReader.GetString(4);
                    customer.State = dataReader.GetString(5);
                    customer.PostalCode = dataReader.GetString(6);
                    customer.PhoneNumber = dataReader.GetString(7);

                    CustomerList.Add(customer);
                }
            }
            sqlConnection.Close();

            return CustomerList; // returns list of customers from database

        }

        public Customer ListCustomers()
        {
            Customer customer = null;
            List<Customer> CustomerList = GetCustomers();
            for (int i = 0; i< CustomerList.Count; i++)
            {
                Console.WriteLine( // prints all customers from db to console
                    (i + 1) + ". " +
                    CustomerList[i].FirstName + " " +
                    CustomerList[i].LastName);
            }

            string chosenCustomer = Console.ReadLine(); // user chooses customer
            int chosenCustomerId = int.Parse(chosenCustomer);
            if (chosenCustomerId >= 0 && chosenCustomerId <= CustomerList.Count)
            {
                customer = CustomerList[chosenCustomerId - 1];
            }

            Console.WriteLine("You chose " + customer.FirstName + ".");

            return customer; // returns chosen customer
            
        }

    }
}
