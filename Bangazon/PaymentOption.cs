using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    public class PaymentOption
    {
        public int IdPaymentOption { get; set; }
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }


        public static PaymentOption CreatePaymentOption()
        {
            Console.WriteLine("Which customer?");
           
            Customer customer = Customer.ListCustomers();

            PaymentOption paymentOption = new PaymentOption();

            paymentOption.IdCustomer = customer.IdCustomer;

            Console.WriteLine("Enter payment type (e.g. AMEX, Visa, Checking)");
            paymentOption.Name = Console.ReadLine();

            Console.WriteLine("Enter account number ");
            paymentOption.AccountNumber = Console.ReadLine();

            // sending data to PaymentOption table
            string command = @" 
                    INSERT INTO PaymentOption
                        (IdCustomer, Name, AccountNumber)
                    VALUES
                        ('" + paymentOption.IdCustomer + "', '" + paymentOption.Name + "', '" + paymentOption.AccountNumber + "')";

            System.Data.SqlClient.SqlConnection sqlConnection1 =
            new System.Data.SqlClient.SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\kaylee cummings\\documents\\visual studio 2015\\Projects\\Bangazon\\Bangazon\\Invoices.mdf\";Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = command;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();


            return paymentOption; // chosen payment option

        }

        //public static PaymentOption GetIdPaymentOption(PaymentOption paymentOption, Customer customer)
        //{
        //    //currentCustomer = ListCustomers();
        //    paymentOption = CreatePaymentOption();
        //    paymentOption.IdCustomer = customer.IdCustomer;


        //    //The SQL Connection to my Invoices Database - GETTING DATA FROM TABLE
        //    SqlConnection sqlConnection = new SqlConnection();
        //    ConnectionString connectionString = new ConnectionString();
        //    var dataSource = connectionString.source;
        //    sqlConnection.ConnectionString = dataSource;

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = System.Data.CommandType.Text;
        //    cmd.CommandText = "SELECT IdPaymentOption, IdCustomer, Name, Account Number FROM PaymentOption";
        //    cmd.Connection = sqlConnection;

        //    sqlConnection.Open();

        //    using (SqlDataReader dataReader = cmd.ExecuteReader())
        //    {
        //        while (dataReader.Read())
        //        {
        //            paymentOption.IdPaymentOption = dataReader.GetInt32(0);
        //            paymentOption.IdCustomer = dataReader.GetInt32(1);
        //            paymentOption.Name = dataReader.GetString(2);
        //            paymentOption.AccountNumber = dataReader.GetString(3);

        //        }
        //    }
        //    sqlConnection.Close();

        //    return paymentOption; // returns paymentOption from table




        //}



    }
}
