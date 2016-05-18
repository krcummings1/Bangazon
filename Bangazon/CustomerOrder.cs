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

        public static void CompleteOrder()
        {
            if (Product.Cart.Count < 1)
            {
                Console.WriteLine("Please add a product to your order.");
                Product.ListProducts();
            }
            else
            {
                float orderTotal = 0;
                foreach (Product prod in Product.Cart)
                {
                    orderTotal += prod.Price;
                }
                Console.WriteLine("Your order total is ${0}. Ready to purchase?", orderTotal);
                Console.Write("(Y/N)");

                string readyOrNot = Console.ReadLine();

                if(readyOrNot == "y" || readyOrNot == "Y")
                {
                    Customer customer = new Customer();
                    PaymentOption paymentOption = new PaymentOption();
                    SendCustomerOrderDataToDB(paymentOption, customer);
                }
                else
                {
                    Bangazon.MainMenu();
                }

            }
        }


        public static void SendCustomerOrderDataToDB(PaymentOption paymentOption, Customer customer)
        {
            Customer cust = new Customer();
            PaymentOption payOpt = new PaymentOption();
            CustomerOrder customerOrder = new CustomerOrder();

            Console.WriteLine("Who is this order for?");
            payOpt = paymentOption.ListByCustomer(customer);
            customerOrder.IdPaymentOption = payOpt.IdPaymentOption;
            customerOrder.IdCustomer = payOpt.IdCustomer;
            customerOrder.Shipping = "UPS";
            customerOrder.OrderNumber = (new Random().Next(int.MaxValue));
            customerOrder.DateCreated = DateTime.Now;
            Console.WriteLine("customer {0}, payment option {1}", customerOrder.IdCustomer, customerOrder.IdPaymentOption);

            string command = @" 
                    INSERT INTO CustomerOrder
                        (OrderNumber, DateCreated, IdCustomer, IdPaymentOption, Shipping)
                    VALUES
                        ('" + customerOrder.OrderNumber + "', '" + customerOrder.DateCreated + "', '" + customerOrder.IdCustomer + "', '" + customerOrder.IdPaymentOption + "', '" + customerOrder.Shipping + "')";

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
            Console.WriteLine("Your order is complete!");
        }


       

    }
}
