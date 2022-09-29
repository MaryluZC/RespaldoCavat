using System.Data.SqlClient;

namespace InfoUsuarios
{
    public class ConecctionToString
    {
        private readonly string connectionString;
        public ConecctionToString()
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
