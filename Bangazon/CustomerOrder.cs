using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    public class CustomerOrder
    {
        public int IdOrder { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DateCreated = new DateTime();
        public int IdCustomer { get; set; }
        public int IdPaymentOption { get; set; }
        public string Shipping { get; set; }

       // List<PaymentOption> PaymentOptionList = new List<PaymentOption>();

        public static List<PaymentOption> ListPaymentOptions(Customer customer)
        {
            // SELECT IdPaymentOption FROM PaymentOption WHERE customer.IdCustomer = paymentOption.IdCustomer 

            Customer currentCustomer = Customer.ListCustomers();
            PaymentOption currentPaymentOption = new PaymentOption();

            currentCustomer.IdCustomer = currentPaymentOption.IdCustomer;

            SqlConnection sqlConnection = new SqlConnection();
            ConnectionString connectionString = new ConnectionString();
            var dataSource = connectionString.source;
            sqlConnection.ConnectionString = dataSource;

            List<PaymentOption> PaymentOptionList = new List<PaymentOption>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT IdPaymentOption, IdCustomer, Name, AccountNumber FROM PaymentOption WHERE currentCustomer.IdCustomer = paymentOption.IdCustomer";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                   // CustomerOrder customerOrder = new CustomerOrder();
                    currentPaymentOption.IdPaymentOption = dataReader.GetInt32(0);
                    currentPaymentOption.IdCustomer = dataReader.GetInt32(1);
                    currentPaymentOption.Name = dataReader.GetString(2);
                    currentPaymentOption.AccountNumber = dataReader.GetString(3);

                    PaymentOptionList.Add(currentPaymentOption);
                }
            }
            sqlConnection.Close();
            
            return PaymentOptionList; // returns list of customers' payment options from database

        }


        public static PaymentOption SelectPaymentOption()
        {
            Console.WriteLine("Select payment option.");

            PaymentOption customersPaymentOption = null;
            //List<PaymentOption> PaymentOptionList = 
            for(int i = 0; i < PaymentOptionList.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) + ". " +
                    PaymentOptionList[1].Name);
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







        //public static void CreateOrderWithAllData(PaymentOption paymentOption, Customer customer)
        //{
        //    DateTime now = DateTime.Now;
        //    int orderNumber = (new Random().Next(int.MaxValue));

        //    Customer currentCustomer = null;
        //    currentCustomer = Customer.ListCustomers();

        //    PaymentOption currentPaymentOption = null;
        //    currentPaymentOption = PaymentOption.GetIdPaymentOption(paymentOption, customer);

        //    CustomerOrder customerOrder = new CustomerOrder();
        //    customerOrder.IdCustomer = currentCustomer.IdCustomer;
        //    customerOrder.IdPaymentOption = currentPaymentOption.IdPaymentOption;

        //    // Console.WriteLine("{0} is placing an order using IdPaymentOption {1}.", currentCustomer, currentPaymentOption);


        //    string command = @" 
        //            INSERT INTO CustomerOrder
        //                (OrderNumber, DateCreated, IdCustomer, IdPaymentOption, Shipping)
        //            VALUES
        //                ('" + customerOrder.OrderNumber + "', '" + customerOrder.DateCreated + "', '" + customerOrder.IdCustomer + "', '" + customerOrder.IdPaymentOption + "', '" + customerOrder.Shipping + "')";

        //    System.Data.SqlClient.SqlConnection sqlConnection1 =
        //    new System.Data.SqlClient.SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\kaylee cummings\\documents\\visual studio 2015\\Projects\\Bangazon\\Bangazon\\Invoices.mdf\";Integrated Security=True");

        //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        //    cmd.CommandType = System.Data.CommandType.Text;
        //    cmd.CommandText = command;
        //    cmd.Connection = sqlConnection1;

        //    sqlConnection1.Open();
        //    cmd.ExecuteNonQuery();
        //    sqlConnection1.Close();



        //}



        //public static void CompleteOrder(List<Product> CustomersOrder)
        //{
        //    if (CustomersOrder.Count < 1)
        //    {
        //        Console.WriteLine("Please add a product to your order.");
        //    }
        //    else
        //    {
        //        // Console.WriteLine("Your order total is {0}. Ready to purchase? (Y/N)", orderTotal);
        //        float orderTotal = 0;
                
            
              
        //    }


        //}












    }
}
