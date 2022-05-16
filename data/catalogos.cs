using System;
using System.Data;
using System.Data.SqlClient;
using InfoUsuarios;

namespace Cavat.data
{
    public class catalogos:ConnectionToString
    {
        public DataTable Catalogo(int opc)
        {
            DataTable catPregunta = new DataTable();

            int nresp = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Catalogos", connection); //extra
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@opcion", opc);

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
        public DataTable CatClaseConstrucion(int opc, int id, string calidad)
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
                    cmd.Parameters.AddWithValue("@tipoPre", calidad);

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