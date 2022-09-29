using System.Data;

namespace InfoUsuarios.infoPredio
{
    public static class infoMunicipio
    {
        public static class Descentralizados
        {
            public static int mensaje { get; set; }
            public static DataTable dtDescentralizados { get; set; }//Dataset que almacena la información de los municipios descentralizados
            public static DataTable dtLocalidades { get; set; }//Dataset que almacena la información de las localidades
        }
        public static class Centralizado
        {
            public static int mensaje { get; set; }
            public static DataTable dtCentralizados { get; set; }//Dataset que almacena la información de los municipios Centralizados
            public static DataTable dtLocalidades { get; set; }//Dataset que almacena la información de las localidades
            public static DataTable ZonasValor { get; set; }//Dataset que almacena la información de las localidades
            public static DataTable UbicacionPredio { get; set; }//Dataset que almacena la información del uso de suelo de municipios descentralizados
            public static DataTable UbicacionManzana { get; set; }//Dataset que almacena la información del uso de suelo de municipios descentralizados
        }

    }
}
