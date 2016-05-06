using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    class Program
    {
        static void Main(string[] args)
        {

            bool isRunning = true;

            Bangazon Bangazon = new Bangazon();
            Customer customer = new Customer();
            //PaymentOption PaymentOption = new PaymentOption();

            while (isRunning)
            {

                Bangazon.MainMenu();
                //ConsoleKeyInfo info = Console.ReadKey();
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        Console.WriteLine("You chose: create an account.");
                        customer.CreateCustomer();

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

                        break;
                    case "2":

                        Customer.GetCustomers();
                        // Customer.ListCustomers();
                        PaymentOption.CreatePaymentOption();


                        break;
                    case "3":
                        Console.WriteLine("You chose: order a product.");
                        break;
                    case "4":
                        Console.WriteLine("You chose: complete an order.");
                        break;
                    case "5":
                        Console.WriteLine("See product availability.");
                        break;
                    case "6":

                        Console.WriteLine("Are you sure you want to leave Bangazon?");
                        isRunning = false;
                        break;
                }





               // Console.ReadLine();
            }
        }
    }
}
