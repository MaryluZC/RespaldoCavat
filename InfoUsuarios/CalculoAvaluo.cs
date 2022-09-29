using System;

namespace InfoUsuarios
{
    public static class factorPredio //PREDIO 
    {
        //Operaciones para Factor de Terreono Urbano y suburbano 
        public static double factorFrente(double frente)
        {
            int k = 6; //Coeficiente que no cambia
            return Math.Sqrt(frente / k);
        }

        public static double factorProfundidad(double frente, double profundidad)
        {
            int k = 4; //Coeficiente que no cambia
            return Math.Sqrt((frente / profundidad) * k);
        }

        public static double factorTopografía(double profundidad, double n, int tipo)
        {
            double m = (n / profundidad) * 100;
            const bool aux = true;
            double factTopografia = 1;
            if (tipo == 1)
            {
                switch (true)
                {
                    case aux when m > 0 && m <= 5.0:
                        factTopografia = 1.0;
                        break;
                    case aux when m > 5.0 && m <= 10.0:
                        factTopografia = 0.95;
                        break;
                    case aux when m > 10.0 && m <= 20.0:
                        factTopografia = 0.90;
                        break;
                    case aux when m > 20.0 && m <= 30.0:
                        factTopografia = 0.85;
                        break;
                    case aux when m > 30.0 && m <= 40.0:
                        factTopografia = 0.80;
                        break;
                    case aux when m > 40.0 && m <= 50.0:
                        factTopografia = 0.70;
                        break;
                    case aux when m > 50.0:
                        factTopografia = 0.65;
                        break;
                }
            }
            if (tipo == 2)
            {
                switch (true)
                {
                    case aux when m > 0 && m <= 10.0:
                        factTopografia = 1.00;
                        break;
                    case aux when m > 10.0 && m <= 20.0:
                        factTopografia = 0.95;
                        break;
                    case aux when m > 20.0 && m <= 30.0:
                        factTopografia = 0.90;
                        break;
                    case aux when m > 30.0 && m <= 40.0:
                        factTopografia = 0.85;
                        break;
                    case aux when m > 40.0 && m <= 50.0:
                        factTopografia = 0.80;
                        break;
                    case aux when m > 50.0:
                        factTopografia = 0.75;
                        break;
                }
            }
            return factTopografia;
        }

        public static double factorSuperficie(double superficie)
        {
            const bool aux = true;
            double factSuperficie = 1;
            switch (true)
            {
                case aux when superficie >= 1.00 && superficie <= 1200.00:
                    factSuperficie = 1.00;
                    break;
                case aux when superficie >= 1201.00 && superficie <= 2500.00:
                    factSuperficie = 0.85;
                    break;
                case aux when superficie >= 2501.00 && superficie <= 5000.00:
                    factSuperficie = 0.75;
                    break;
                case aux when superficie > 5000.00:
                    factSuperficie = 0.70;
                    break;
            }
            return factSuperficie;
        }

        public static double factorEsquina(double superficie, int uso)
        {
            double factEsquina = 1;
            switch (uso)
            {
                case 1 when superficie >= 1.00 && superficie <= 200.00:
                    factEsquina = 1.05;
                    break;
                case 1 when superficie >= 201.00 && superficie <= 400.00:
                    factEsquina = 1.03;
                    break;
                case 1 when superficie >= 401.00 && superficie <= 700.00:
                    factEsquina = 1.02;
                    break;
                case 1 when superficie >= 701.00 && superficie <= 2000.00:
                    factEsquina = 1.01;
                    break;
                case 1 when superficie >= 2001.00 && superficie <= 10000.00:
                    factEsquina = 1.00;
                    break;

                case 2 when superficie >= 1.00 && superficie <= 700.00:
                    factEsquina = 1.10;
                    break;
                case 2 when superficie >= 701.00 && superficie <= 2000.00:
                    factEsquina = 1.05;
                    break;
                case 2 when superficie >= 2001.00 && superficie <= 10000.00:
                    factEsquina = 1.02;
                    break;

                case 3 when superficie >= 1.00 && superficie <= 700.00:
                    factEsquina = 1.15;
                    break;
                case 3 when superficie >= 701.00 && superficie <= 2000.00:
                    factEsquina = 1.10;
                    break;
                case 3 when superficie >= 2001.00 && superficie <= 10000.00:
                    factEsquina = 1.05;
                    break;

                default:
                    factEsquina = 1.00;
                    break;
            }
            return factEsquina;
        }
        public static double factorCabeceroManza(double superficie, int categoria, int uso, int numEsquinas)
        {
            if (categoria == 0) //inferior a calle opcion andador, callejon o privada de ddlTipoVialidad
            {
                return factorEsquina(superficie, uso);
            }
            else
            {
                superficie = superficie / numEsquinas;
                return factorEsquina(superficie, uso);
            }
        }

        public static double factorManzanero(double superficie, int categoria, int uso, int numEsquinas, int esquinasColindantes)
        {
            if (categoria == 0) //inferior a calle
            {
                numEsquinas = numEsquinas - esquinasColindantes;
                superficie = superficie / numEsquinas;
                return factorEsquina(superficie, uso);
            }
            else  //(categoria == 1) //calle o superior
            {
                superficie = superficie / numEsquinas;
                return factorEsquina(superficie, uso);
            }
        }
        //Operaciones para Factor de Terreono Urbano y suburbano 
        public static double FactoResultanteTerreno(double ftFrente, double ftProfundidad, double ftTopografia, double ftUbicacion, double ftSuperficie, double ftEsquina)
        {
            double factorResultante = 0.0F;
            return factorResultante = (ftFrente * ftProfundidad * ftTopografia * ftUbicacion * ftSuperficie * ftEsquina);
        }

        //Operaciones para Factor de Terreono RUSTICO
        public static double FactoResultanteTerrenoRustico(double ftSuperficie, double ftTopografia, double ftDistanciaPredio, double ftUbicacion)
        {
            double factorResultante = 0.0F;
            return factorResultante = (ftSuperficie * ftTopografia * ftUbicacion * ftDistanciaPredio);
        }

        //Metodo para obtner el valor catastral 
        public static double ValorCatastralPredio(double Vcsu, double FR, double St)
        {
            double VCPred = 0.0F;
            VCPred = Vcsu * FR * St;
            return VCPred;
        }
    }


}
