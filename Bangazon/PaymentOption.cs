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

            Customer cust = new Customer();
            Customer customer = cust.ListCustomers();
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


            return paymentOption; // payment option created

        }

        public PaymentOption ListByCustomer(Customer customer) // lists payment methods by customerid
        {
            // SELECT IdPaymentOption FROM PaymentOption WHERE customer.IdCustomer = paymentOption.IdCustomer 
            Customer cust = new Customer();
            Customer currentCustomer = cust.ListCustomers(); // sets currentCustomer to customer chosen from list

            List<PaymentOption> PaymentOptionList = new List<PaymentOption>();

            SqlConnection sqlConnection = new SqlConnection();
            ConnectionString connectionString = new ConnectionString();
            var dataSource = connectionString.source;
            sqlConnection.ConnectionString = dataSource;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT IdPaymentOption, PaymentOption.IdCustomer, Name, AccountNumber FROM PaymentOption INNER JOIN Customer ON Customer.IdCustomer = PaymentOption.IdCustomer WHERE PaymentOption.IdCustomer = " + currentCustomer.IdCustomer; // gets data from PaymentOption table
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())

                {
                    PaymentOption currentPaymentOption = new PaymentOption();
                    currentPaymentOption.IdPaymentOption = dataReader.GetInt32(0);
                    currentPaymentOption.IdCustomer = dataReader.GetInt32(1);
                    currentPaymentOption.Name = dataReader.GetString(2);
                    currentPaymentOption.AccountNumber = dataReader.GetString(3);

                    PaymentOptionList.Add(currentPaymentOption);
                }
            }
            sqlConnection.Close();

            Console.WriteLine("Select payment option.");

            PaymentOption customersPaymentOption = null;
            
            for (int i = 0; i < PaymentOptionList.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) + ". " +
                    PaymentOptionList[i].Name); // lists payment options for chosen customer
            }

            string chosenPaymentOption = Console.ReadLine();
            int chosenPaymentOptionId = int.Parse(chosenPaymentOption);
            if (chosenPaymentOptionId >= 0 && chosenPaymentOptionId <= PaymentOptionList.Count)
            {
                customersPaymentOption = PaymentOptionList[chosenPaymentOptionId - 1];
            }

            Console.WriteLine("You chose " + customersPaymentOption.Name + ".");
            return customersPaymentOption;
        }



    }
}
