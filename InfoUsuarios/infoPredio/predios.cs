using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace InfoUsuarios.infoPredio
{

    public static class predios
    {
        //Valores resultantes de las operaciones 
        public static double ValorFactorConstruccion { get; set; } //    
        public static double ValorFactorObrasCom { get; set; } //    

        //VARIABLES PARA REALIZAR OPERACIONES 
        public static double superficie { get; set; } //           
        public static double factorSuperficie { get; set; } //Factor
        public static double ValorCatastralTerreno { get; set; } //Factor final de la valuacion 
        public static double factorTopografia { get; set; }//Factor de topografia. Aplica para todos los tipos de predio.
        public static double factorUbicacion { get; set; }//Factor de ubicacion. Aplica para todos los tipos de predio.

        //VARIABLES PARA ALMACENAR INFORMACION QUE SE VA A IMPRIMIR.
        public static string municipio { get; set; } // 
        public static string centralizado { get; set; } // 
        public static string superficieRU { get; set; }//no se elimina debido a la transformacion        
        public static string tipoPredio { get; set; } //
        public static string usoSuelo { get; set; }
        public static string topoReliev { get; set; }
        public static string ubicacion { get; set; } // EN TEXTO 
        public static string tieneConst { get; set; }
        public static string ZonaValorTxt { get; set; }
        public static DataTable infoMunicipio { get; set; }//Almacena la informacion del municipio
    }

    public static class datosUbicacionPredio
    {
        public static DataTable municipio { get; set; }
        public static string tipoPredio { get; set; }
        public static string paraje { get; set; }
        public static string localidad { get; set; }
        public static string zonaValor { get; set; }
        public static string calle { get; set; }
        public static string numero { get; set; }
        public static string colonia { get; set; }
        public static string codigoPostal { get; set; }
    }

 
}

