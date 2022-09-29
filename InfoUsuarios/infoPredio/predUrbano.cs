using System.Data;

namespace InfoUsuarios.infoPredio
{
    public class predUrbano
    {
        //VALORES PARA REALIZAR OPERACINES
        public static double factorFrente { get; set; }//FACTOR
        public static double factorProfundidad { get; set; }//FACTOR 
        public static double factorTopografia { get; set; } //FACTOR  
        public static double factorUbicacion { get; set; } //FACTOR 
        public static double factorEsquina { get; set; } // FACTOR
        public static double factorResultanteTERRENO { get; set; } // FACTOR
        public static double tamprofundidad { get; set; }        //VALORES PARA REALIZAR OPERACINES
        /// <summary>
        /// -
        /// </summary>
        public static string localidad { get; set; }
        public static string zonaValor { get; set; }
        public static string calle { get; set; }
        public static string numero { get; set; }
        public static string colonia { get; set; }
        public static string cp { get; set; }
        public static double tamfrente { get; set; }
        public static string exisDesnivel { get; set; }
        public static string tipoDesnivel { get; set; }
        public static string vialidad { get; set; }
        public static string noesquinas { get; set; }
        public static double anguloEsquinas { get; set; }
        public static string noEsquinasColinadantes { get; set; }
        public static string fraccionamiento { get; set; }
        public static string ubicacionManzana { get; set; }

        //METODO OBJETO

        public static DataTable dataUrbano()
        {
            DataTable dtUrbano = new DataTable();
            dtUrbano.Columns.AddRange(new DataColumn[9]{ new DataColumn("zona"), new DataColumn("superficie"), new DataColumn("valorm2"),
                new DataColumn("ftsuperf"), new DataColumn("ftfrente"), new DataColumn("fttopo"),new DataColumn("ftesquina"),
                new DataColumn("ftresultante"), new DataColumn("Importe")});
            dtUrbano.Rows.Add(1, predios.ZonaValorTxt);//texto
            dtUrbano.Rows.Add(2, predios.superficie);
            dtUrbano.Rows.Add(3, zonaValor);//Valor double
            dtUrbano.Rows.Add(4, factorFrente);
            dtUrbano.Rows.Add(5, factorFrente);
            dtUrbano.Rows.Add(6, factorTopografia);
            dtUrbano.Rows.Add(7, factorEsquina);
            dtUrbano.Rows.Add(8, factorResultanteTERRENO);//importe del factor terreno
            //put a breakpoint here and check datatable
            return dtUrbano;
        }

    }

    public class cleanUrbanos
    {
        public void cleanUr()
        {
            predUrbano.localidad = "";
            predUrbano.zonaValor = "";
            predUrbano.calle = "";
            predUrbano.numero = "";
            predUrbano.colonia = "";
            predUrbano.cp = "";
            predUrbano.tamfrente = 0.0;
            predUrbano.tamprofundidad = 0.0;
            predUrbano.exisDesnivel = "";
            predUrbano.tipoDesnivel = "";
            predUrbano.vialidad = "";
            predUrbano.noesquinas = "";
            //predUrbano.anguloEsquinas = "";
            predUrbano.noEsquinasColinadantes = "";
            predUrbano.fraccionamiento = "";
        }
    }


}
