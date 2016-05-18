using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    public class OrderProducts
    {
        public int IdOrderProducts { get; set; }
        public int IdProduct { get; set; }
        public int IdOrder { get; set; }


        public static void GetCustomerOrderData()
        {
            SqlConnection sqlConnection = new SqlConnection();
            ConnectionString connectionString = new ConnectionString();
            var dataSource = connectionString.source;
            sqlConnection.ConnectionString = dataSource;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT CustomerOrder.IdOrder FROM CustomerOrder INNER JOIN Product ON Product.IdProduct = PaymentOption.IdCustomer WHERE PaymentOption.IdCustomer = " + currentCustomer.IdCustomer; // gets data from PaymentOption table
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

            return;
        }



        //public static void SendDataToOrderProducts()
        //{

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









    }
}
