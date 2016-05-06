using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bangazon
{
    public class ConnectionString
    {
        public string source { get; set; }


        public ConnectionString()
        {
            this.source = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =\"c:\\users\\kaylee cummings\\documents\\visual studio 2015\\Projects\\Bangazon\\Bangazon\\Invoices.mdf\";Integrated Security=True";
        }


    }
}
