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
            PaymentOption paymentOption = new PaymentOption();

            while (isRunning)
            {

                Bangazon.MainMenu();
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":

                        customer.CreateCustomer();

                        break;
                    case "2":

                        Customer.GetCustomers();
                        PaymentOption.CreatePaymentOption();

                        break;
                    case "3":

                        Product.GetProducts();
                        Product.ListProducts();
                       
                        break;
                    case "4":

                        CustomerOrder.CompleteOrder();

                        break;
                    case "5":
                        Console.WriteLine("See product availability.");
                        break;
                    case "6":
                        Console.WriteLine("Are you sure you want to leave Bangazon?");
                        Console.WriteLine("(Y/N)");
                        string value = Console.ReadLine();
                        if (value == "N" || value == "n")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            isRunning = false;
                            break;
                        }
                }



                // send data to OrderProducts table after order is complete

               // Console.ReadLine();
            }
        }
    }
}
