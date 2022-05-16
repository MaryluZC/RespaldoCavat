using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cavat.data
{
    public class ConnectionToString
    {
        private readonly string connectionString;
        public ConnectionToString()
        {
            //connectionString = "Server=DC-CARTO-08\\SQLEXPRESS;DataBase=prueba;integrated security=true";
            connectionString = "Server=DC-CARTO-08\\SQLEXPRESS;DataBase=Cavat; User=sa;Password=a1a2a3*;";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}