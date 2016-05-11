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
                CustomerOrder currentOrder = new CustomerOrder();
                foreach (Product prod in Product.Cart)
                {
                    orderTotal += prod.Price;
                }
                Console.WriteLine("Your order total is ${0}. Ready to purchase", orderTotal);
                Console.Write("(Y/N) >");
            }
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
