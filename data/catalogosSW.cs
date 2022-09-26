using Cavat.ServiceCavat;//importar Libreria de SErvicio
using InfoUsuarios;
using System;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// | Autor: Ing. Maria de Lourdes Sosa Cruz
/// | Clase para el consumo del servicio web de los catalogos para el llenado de las listas desplegables
/// </summary>
namespace Cavat.data
{
    public class catalogosSW : ConnectionToString
    {
        ServiceCavatClient swCavat = new ServiceCavatClient();// instancia para acceso al servicio 
       wRespuesta res = new wRespuesta(); //respuestas del servicio
        resultado rs = new resultado();
        public resultado Cataloggo(int opc)//
        {
            res = swCavat.VerCatalogo(opc);//CONSUMO DE SERVICIO WEB            
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }
        public resultado CatalogCons(int opc, int municipio, int anio)
        {
            res = swCavat.VerCatConstruccion(opc, municipio, anio);//CONSUMO DE SERVICIO WEB    
            rs.laDataTable = rs.laDataTable;
            return rs;
        }
        public resultado CatConstruccion(int opc, int municipio, int anio)
        {
            res = swCavat.VerCatConstruccion(opc, municipio, anio);//CONSUMO DE SERVICIO WEB
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }   
        public resultado CatZonasValorDesCentralizados(int opc, string  municipio, string anio)
        {
            try
            {
                res = swCavat.VerCatZonasDesCentralizados(opc, municipio, anio);//CONSUMO DE SERVICIO WEB
                rs.mensaje = res.mensaje;
                rs.elDataSet = res.elDataSet;
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public resultado CatZonasValorCentralizados(int opc, int idmun, char tipoPredio, string anio)
        {
            try
            {
                res = swCavat.VerCatZonasCentralizados(opc, idmun, tipoPredio, anio);//CONSUMO DE SERVICIO WEB
                rs.mensaje = res.mensaje;
                rs.elDataSet = res.elDataSet;
                return rs;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public resultado CatLocalidadesDesCentralizados(int opc, string municipio) //LOCALIDADES DESCENTRALIZADOS
        {
            res = swCavat.VerCatLocalidadesDes(opc, municipio);//CONSUMO DE SERVICIO WEB
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }
        public resultado CatLocalidadesCentralizados(int opc, int municipio)//LOCALIDADES CENTRALIZADOS
        {
            res = swCavat.VerCatLocalidadesCentr(opc, municipio);//CONSUMO DE SERVICIO WEB
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }
        public resultado CatUbicacionPredio(int opc, int tipoPredio)//Ubicacion del predio aplica para centralizados y descentralizados la diferencia es que para tipo de predio 1 es ubicacion de manzana y para 2 ubicacion sobre el predio
        {
            res = swCavat.VerCatUbicacion(opc, tipoPredio);//CONSUMO DE SERVICIO WEB
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }
        public resultado CatUsoGeneral(int opc, string tipoPredio)//Se utiliza en distintos apartados para llenar el dropdown lista, puede mejorarse la tecnica
        {
            res = swCavat.VerCatGeneral(opc,tipoPredio);//CONSUMO DE SERVICIO WEB
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }
        public resultado CatUsoSuelo(int opc, string Predio)//Se utiliza especificamente para llenar el uso de suelo, se puede mejorar pero hay que mover las variables en el procedimiento almacenado en la base de datos
        {
            res = swCavat.VerCatUsoSuelo(opc, Predio);//CONSUMO DE SERVICIO WEB
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }
        public resultado CatClasifConstCentralizados(int opc, string anio, string municipio)//Se utiliza especificamente para llenar el uso de suelo, se puede mejorar pero hay que mover las variables en el procedimiento almacenado en la base de datos
        {
            try
            {
                res = swCavat.CatalogConstCentralizados(opc, anio, municipio);//CONSUMO DE SERVICIO WEB
                rs.mensaje = res.mensaje;
                rs.elDataSet = res.elDataSet;
                return rs;
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        public DataTable CatTipoPredC(int opc, int id)
        {
            DataTable catPregunta = new DataTable();

            int nresp = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Catalogos", connection); //Nombre del procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@opcion", opc);
                    cmd.Parameters.AddWithValue("@clasificacion", id);

                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(catPregunta);//para llenar una tabla 
                    adapter.Dispose();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return catPregunta;
        }
        public DataTable CatClaseConstrucion(int opc, string calidad, int id)
        {
            DataTable catPregunta = new DataTable();

            int nresp = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Catalogos", connection); //Nombre del procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@opcion", opc);
                    cmd.Parameters.AddWithValue("@clasificacion", id);
                    cmd.Parameters.AddWithValue("@tipoConstriccion", calidad);

                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(catPregunta);//para llenar una tabla 
                    adapter.Dispose();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return catPregunta;
        }
        public DataTable CatTipoPredCons(int opc, int id)
        {
            DataTable catPregunta = new DataTable();

            int nresp = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Catalogos", connection); //Nombre del procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@opcion", opc);
                    cmd.Parameters.AddWithValue("@clasificacion", id);

                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(catPregunta);//para llenar una tabla 
                    adapter.Dispose();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return catPregunta;
        }

      
    }
}