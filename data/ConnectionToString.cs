using System.Data.SqlClient;
/// <summary>
/// | Autor: Ing. Maria de Lourdes Sosa Cruz
/// Clase para realizar la conexion con la base de datos local
/// En la base de datos local solo se contiene la informacion de los usuarios registrados
/// la informacion de los municipios descentralizados y se agregara la informacion para el control 
/// de pagos y las veces que el usuario utilice el sistema. 
/// </summary>
namespace Cavat.data
{
    public class ConnectionToString
    {
        private readonly string connectionString;
        private readonly string connectionStringServer;
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