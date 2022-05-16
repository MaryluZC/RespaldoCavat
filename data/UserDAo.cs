using InfoUsuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cavat.data
{
    public class UserDAo : ConnectionToString
    {
        public DataSet ListSolicitudes(int opc)
        {
            using (var connection = GetConnection())
            {
                //DataTable tbl = new DataTable();
                DataSet tbl = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("Admin", connection);
                try
                {
                    connection.Open();
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@opc", opc);
                    adapter.Fill(tbl);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    connection.Close();
                }
                return tbl;
            }
        }
        public int ChangePass(string pass, int opc, string user)
        {
            using (var connection = GetConnection())
            {
                DataTable tbl = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                int nresp = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("Admin", connection); //extra
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@pss", pass);
                    cmd.Parameters.AddWithValue("@opc", opc);
                    cmd.Parameters.AddWithValue("@user", user);
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return nresp;
            }
        }

        public int ChangeInfoUserr(string nombre, string ape1, string ape2, string correo, string pss, string cedula, string telcel, int opc)
        {
            using (var connection = GetConnection())
            {
                DataTable tbl = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                int nresp = 0;
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Admin", connection); //extra
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@ape1", ape1);
                    cmd.Parameters.AddWithValue("@ape2", ape2);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@pss", pss);
                    cmd.Parameters.AddWithValue("@telcel", telcel);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@opc", opc);

                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    connection.Close();
                }
                return nresp;
            }
        }
        public int DeleteUserr(string cedula, int opc)
        {
            using (var connection = GetConnection())
            {
                DataTable tbl = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                int nresp = 0;
                try
                {
                    SqlCommand cmd = new SqlCommand("Admin", connection); //extra
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@opc", opc);
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return nresp;
            }
        }

        public int ChangeStatusAprob(string user, string pass, int opc, string cedula)
        {
            using (var connection = GetConnection())
            {
                DataTable tbl = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                int nresp = 0;
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Admin", connection); //extra
                    cmd.CommandType = CommandType.StoredProcedure; //extra
                    SqlParameter returno = new SqlParameter();//extra
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pss", pass);
                    cmd.Parameters.AddWithValue("@opc", opc);
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    mnsg.mensaje = (int)returno.Value;
                    nresp = mnsg.mensaje;                    


                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally
                {
                    connection.Close();
                }
                return nresp;
            }
        }



    }
}