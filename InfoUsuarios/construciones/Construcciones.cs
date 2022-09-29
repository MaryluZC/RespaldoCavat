using System.Data;
/*
 * | Autor: Ing. Maria de Lourdes Sosa Cruz
 * | metodos para almacenar la informacion de las construcciones
 */
namespace InfoUsuarios.construciones
{
    public static class Construcciones
    {
        public static int mensaje { get; set; }
        public static DataSet dtConstrucciones { get; set; }//Dataset que almacena la informacion general de la construccion dependiendo del municipio al que pertenesca el predio.
    }
    //Almacena los valores Generales de la construccion 
    public static class infoConstrucciones
    {
        public static double St { get; set; }//Superficie total del terreno
        public static double Sc { get; set; }//Superficie total de la construccion
        public static double VCUS { get; set; }//Valor catastral del suelo unitario
        public static double VCUC { get; set; }//Valor Catastral de Construccion nueva
        public static double VCpubcons { get; set; }//Valor Catastral de Construccion publicado
        public static string ClasificacionConstruccion { get; set; }//clasificacion de la construccion
        public static string CalidadConstruccion { get; set; }//calidad de la construccion
        public static string AvanceConstruccion { get; set; }//avance de la construccion
        public static string edoConservacionConstruccion { get; set; }//estado de conservacion de la construccion
        public static string edadConstruccion { get; set; }//edad de la construccion
        public static string obraComplementaria { get; set; }//obra complementaria de la construccion


    }
    //Almacena la informacion de las construcciones que pertenecen a un CONDOMINIO
    //para poder realizar el calculo del valor de la construccion
    public static class infoConsCondominio
    {
        public static double SIT { get; set; } //Superfice Indivisa del Terreno
        public static double SPC { get; set; } //Superfice Privativa de la construccion
        public static double SIC { get; set; } //Superfice Indivisa de la construccion
    }
    //Almacena la informacion de las construcciones que NO ** pertenecen a un CONDOMINIO
    //para poder realizar el calculo del valor de la construccion
    public static class infoConsRegular
    {
        public static double FTR { get; set; } //Factor de Terminacion
        public static double FED { get; set; } //Factor de Edad 
        public static double FCons { get; set; } //Factor de Conservacion
        //Calculo del valor unitario de la construccion 
        public static double VCCRegular(double VC, double fRes, double Sc)//, double valorpub)// (valorcatastralUnitarioconstruccion X factorConstruccion X factorEdad x superfice de la construccion)
        {
            double res = (VC * fRes * Sc);//*valorpub;
            return res; //devolver resultado
        }
        public static double VFacResultante(double fConservacion, double fterminacion, double fEdd)//Obtiene el factor resultante de las construcciones 
        {
            double res = (fConservacion * fterminacion * fEdd);
            return res;
        }
        public static double VCCObraComplementaria(double superficie, double valor)//, double valorpub)// (valorcatastralUnitarioconstruccion X factorConstruccion X factorEdad x superfice de la construccion)
        {
            double res = (superficie * valor);//*valorpub;
            return res; //devolver resultado
        }
       

    }



}
