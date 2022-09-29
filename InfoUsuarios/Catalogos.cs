using System;
using System.Data;
using System.Data.SqlClient;
/*
 * | Autor: Ing. Maria de Lourdes Sosa Cruz
 * | metodos para devolver catalogos
 */
namespace InfoUsuarios
{
    public class Catalogos : ConecctionToString
    {
        public DataTable Catalogo(int opc)
        {
            DataTable catPregunta = new DataTable();
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
                    int nresp = mnsg.mensaje;
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

        public DataTable CatCalidadObra(int opc, string calidad)
        {
            DataTable catCalidad = new DataTable();

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
                    cmd.Parameters.AddWithValue("@obrasCom", calidad);

                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(catCalidad);//para llenar una tabla 
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
            return catCalidad;
        }

        //------------------  LOCALIDADES DE MUNICIPIOS DESCENTRALIZADOS-------------------------
        public DataTable CatLocalidades(int opc, string mun)
        {
            DataTable catCalidad = new DataTable();

            int nresp = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("catalogoDescentralizados", connection); //Nombre del procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@opcion", opc);
                    cmd.Parameters.AddWithValue("@municipio", mun);
                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(catCalidad);//para llenar una tabla 
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
            return catCalidad;
        }

        public DataTable CatConstrucciones(int opc, int municipio, int anio)//el nombre no influye porque esta llenando varios catalogos con este mismo metodo, y os valores devultos dependen de sus variables
        {
            DataTable catCosntruccion = new DataTable();
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spConstrucciones", connection); //Nombre del procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@opcion", opc);
                    cmd.Parameters.AddWithValue("@año", municipio);
                    cmd.Parameters.AddWithValue("@municipio", anio);
                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    int nresp = mnsg.mensaje;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(catCosntruccion);//para llenar una tabla 
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
            return catCosntruccion;
        }
        public DataTable nombreDocumento(int opc, string cedula)
        {
            DataTable documento = new DataTable();
            int nresp = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Admin", connection); //Nombre del procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@opc", opc);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(documento);//para llenar una tabla 
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
            return documento;
        }

    }
}
