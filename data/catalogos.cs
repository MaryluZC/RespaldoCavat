using Cavat.ServiceCavat;
using InfoUsuarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Cavat.data
{
    public class catalogos : ConnectionToString
    {
        ServiceCavatClient swCavat = new ServiceCavatClient();
        wRespuesta res = new wRespuesta();
        resultado rs = new resultado();

        public resultado Cataloggo(int opc)
        {
            res = swCavat.VerCatalogo(opc);//CONSUMO DE SERVICIO WEB
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }

        public DataTable CatLocalidad(int opc, int idMun)
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
                    cmd.Parameters.AddWithValue("@idmun", idMun);

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


        //public DataTable CatClaidadObra(int opc, string calidad)
        //{
        //    DataTable catCalidad = new DataTable();

        //    int nresp = 0;
        //    using (var connection = GetConnection())
        //    {
        //        try
        //        {
        //            connection.Open();
        //            SqlCommand cmd = new SqlCommand("Catalogos", connection); //Nombre del procedimiento almacenado
        //            cmd.CommandType = CommandType.StoredProcedure; //extra
        //            SqlParameter returno = new SqlParameter();//extra
        //            returno.Direction = ParameterDirection.ReturnValue;
        //            cmd.Parameters.Add(returno);
        //            cmd.Parameters.AddWithValue("@opcion", opc);
        //            cmd.Parameters.AddWithValue("@obrasCom", calidad);

        //            object result = cmd.ExecuteScalar();
        //            connection.Close();
        //            mnsg.mensaje = (int)returno.Value;
        //            nresp = mnsg.mensaje;
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            adapter.Fill(catCalidad);//para llenar una tabla 
        //            adapter.Dispose();
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return catCalidad;
        //}



    }
}