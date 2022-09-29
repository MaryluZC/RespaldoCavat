using System.Data;
/*
 * | Autor: Ing. Maria de Lourdes Sosa Cruz
 * | metodos para almacenar la informacion de los usuarios
 */
namespace InfoUsuarios
{

    public class entrarLogin
    {
        public string user { get; set; }
        public string contrasena { get; set; }
        public int opc1 { get; set; }

    }


    public class solicitudCambioPass : entrarLogin
    {
        public int cambioPsw { get; set; }
    }

    public class resultado
    {
        public int mensaje { get; set; }
        public DataSet elDataSet { get; set; }
        public DataTable laDataTable { get; set; }
    }

    public class dataUser : solicitudCambioPass
    {
        public string nombre { get; set; }
        public string ape1 { get; set; }
        public string ape2 { get; set; }
        public string correo { get; set; }
        public string cedulaP { get; set; }
        public int idPregunta { get; set; }
        public string respuesta { get; set; }
        public string telCel { get; set; }
        public int numNotaria { get; set; }
        public int idStatus { get; set; }
        public int intentos { get; set; }
        public int bloqueado { get; set; }
        public string idTipoUser { get; set; }
        public int idTipoDoc { get; set; }
        public string nombreDoc { get; set; }
    }
    public class mnsg { public static int mensaje = 0; }

    public class usoSuelo
    {
        public static string tipoPredio { get; set; }
    }
}
