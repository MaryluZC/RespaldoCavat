using System;

namespace InfoUsuarios
{
    public class Conversiones
    {
        static string cad;
        static string fmt;
        static double valor;
        static string numeF;
        public static string converMetrosM(string superficie)
        {
            try
            {
                if (superficie != "")
                {
                    cad = superficie.Replace("-", string.Empty);
                    fmt = "000000000.00";
                    valor = double.Parse(cad);//
                    numeF = valor.ToString(fmt);
                }
                else
                {
                    numeF = "Superficie";
                }
                return numeF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string converHA(string superficie)
        {
            try
            {
                if (superficie != "")
                {
                    cad = superficie.Replace("-", string.Empty);
                    fmt = "00-00-00-00.00";
                    valor = double.Parse(cad);
                    numeF = valor.ToString(fmt);
                }
                else
                {
                    numeF = "Distancia";
                }
                return numeF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string convertMeter(string distancia)
        {
            try
            {
                double a = Convert.ToDouble(distancia);
                numeF = (a * 1000.00).ToString();
                return numeF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string convertKm(string distancia)
        {
            try
            {
                double a = Convert.ToDouble(distancia);
                numeF = (a / 1000.00).ToString();
                return numeF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
