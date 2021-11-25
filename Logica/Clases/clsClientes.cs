using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace Web.Clases
{
    public class clsClientes
    {
        string stConexion="";
        SqlCommand sqlcomand=null; //permite ejecutar un comando sql ya sea un query o un procedimiento almacenado
        SqlConnection sqlconnection = null; // permite establecer conexion con servidor de base de datos
        SqlParameter sqlparameter = null; // permite manejar los parametros a nivel de procedimiento almacenados
        SqlDataAdapter sqladapter = null; // adapta un origen de dato, ejemplo dataset o data table


        public clsClientes()
        {
            clsConexion objconexion = new clsConexion();
            stConexion = objconexion.stGetConexion();
        }

        public DataSet mostrarClientes()
        {
            try
            {
                DataSet dsconsulta = new DataSet();

                sqlconnection = new SqlConnection(stConexion);
                sqlconnection.Open();

                sqlcomand = new SqlCommand("",sqlconnection);
                sqlcomand.CommandType = CommandType.Text;
                sqlcomand.CommandText = "SELECT * FROM tbClientes";
                sqlcomand.ExecuteNonQuery();
                sqladapter = new SqlDataAdapter(sqlcomand);
                sqladapter.Fill(dsconsulta);

                return dsconsulta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        public DataSet stconsultarClientes(long id)
        {
            try
            {
                DataSet dsconsulta = new DataSet();

                sqlconnection = new SqlConnection(stConexion);
                sqlconnection.Open();

                sqlcomand = new SqlCommand("spConsultarClientes", sqlconnection);
                sqlcomand.CommandType = CommandType.StoredProcedure;

                sqlcomand.Parameters.Add(new SqlParameter("@id", id));
               
                sqlcomand.ExecuteNonQuery();
                sqladapter = new SqlDataAdapter(sqlcomand);
                sqladapter.Fill(dsconsulta);

                return dsconsulta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        public string stInsertarClientes( string nombre, string apellidos)
        {
            try
            {

            
                sqlconnection = new SqlConnection(stConexion);
                sqlconnection.Open();

                sqlcomand = new SqlCommand("spInsertarClientes", sqlconnection);
                sqlcomand.CommandType = CommandType.StoredProcedure;
                
                sqlcomand.Parameters.Add(new SqlParameter("@nombre", nombre));
                sqlcomand.Parameters.Add(new SqlParameter("@apellidos", apellidos));

                sqlparameter = new SqlParameter();
                sqlparameter.ParameterName = "@mensaje";
                sqlparameter.SqlDbType = SqlDbType.VarChar;
                sqlparameter.Size = 100;
                sqlparameter.Direction = ParameterDirection.Output;

                sqlcomand.Parameters.Add(sqlparameter);
                sqlcomand.ExecuteNonQuery();

                return sqlparameter.Value.ToString();
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        public string stModificarClientes(long id, string nombre, string apellidos)
        {
            try
            {


                sqlconnection = new SqlConnection(stConexion);
                sqlconnection.Open();

                sqlcomand = new SqlCommand("spModificarClientes", sqlconnection);
                sqlcomand.CommandType = CommandType.StoredProcedure;

                sqlcomand.Parameters.Add(new SqlParameter("@id", id));
                sqlcomand.Parameters.Add(new SqlParameter("@nombre", nombre));
                sqlcomand.Parameters.Add(new SqlParameter("@apellidos", apellidos));

                sqlparameter = new SqlParameter();
                sqlparameter.ParameterName = "@mensaje";
                sqlparameter.SqlDbType = SqlDbType.VarChar;
                sqlparameter.Size = 100;
                sqlparameter.Direction = ParameterDirection.Output;

                sqlcomand.Parameters.Add(sqlparameter);
                sqlcomand.ExecuteNonQuery();

                return sqlparameter.Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public string stEliminarClientes(long id)
        {
            try
            {


                sqlconnection = new SqlConnection(stConexion);
                sqlconnection.Open();

                sqlcomand = new SqlCommand("spEliminarClientes", sqlconnection);
                sqlcomand.CommandType = CommandType.StoredProcedure;

                sqlcomand.Parameters.Add(new SqlParameter("@id", id));

                sqlparameter = new SqlParameter();
                sqlparameter.ParameterName = "@mensaje";
                sqlparameter.SqlDbType = SqlDbType.VarChar;
                sqlparameter.Size = 100;
                sqlparameter.Direction = ParameterDirection.Output;

                sqlcomand.Parameters.Add(sqlparameter);
                sqlcomand.ExecuteNonQuery();

                return sqlparameter.Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}