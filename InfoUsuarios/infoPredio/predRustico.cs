/*
 * | Autor: Ing. Maria de Lourdes Sosa Cruz
 * | Almacenamiento de la informacion de los predios rusticos
 */
namespace InfoUsuarios.infoPredio
{
    public class predRustico
    {
        //VARIABLES PARA REALIZAR OPERACIONES  
        public static double fatorSuperficieR { get; set; }//Factor de superficie del terreno
        public static double SuperficieR { get; set; }//superficie del terreno expresado en metros cuadrados
        public static double ValorTerrenoM2 { get; set; }//Factor Valor del terreno por hertacera / 10mil
        public static double factorTopografia { get; set; }//Factor de topografia. Aplica para todos los tipos de predio.
        public static double fatorDistanciaPredio { get; set; }//Factor de topografia. Aplica para todos los tipos de predio.
        public static double factorUbicacion { get; set; }//Factor de distancia predio
        public static double factorResultanteTR { get; set; } // FACTOR

        //VARIABLES PARA ALMACENAR INFORMACION QUE SE VA A IMPRIMIR.
        public static string paraje { get; set; }
        public static string tipoSuelo { get; set; }
        public static string clave { get; set; }
        public static string distanciaPredio { get; set; }
    }
    
    public class cleanRusticos
    {
        public void cleanR()
        {
            predRustico.paraje = "";
            predRustico.tipoSuelo = "";
            predRustico.distanciaPredio = "";
            predRustico.clave = "";
        }
    }
}
