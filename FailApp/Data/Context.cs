using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Data
{
    public class Context
    {
        public SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            //builder.DataSource = "(localdb)\\MSSQLLocalDB"; //Sesión Yair
            builder.DataSource = "DESKTOP-BEMUAFC\\SQLEXPRESS"; //Sesión Iván
            builder.IntegratedSecurity = true;
            //builder.UserID = "<your_username>";
            //builder.Password = "<your_password>";
            builder.InitialCatalog = "FailAppDB";

            return new SqlConnection(builder.ConnectionString);
        }
    }
}
