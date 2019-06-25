using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaPersistencia
{
    public class ClienteDAO
    {
        #region singleton
        private static readonly ClienteDAO UnicaInstancia = new ClienteDAO();
        public static ClienteDAO Instancia
        {
            get
            {
                return ClienteDAO.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public ClienteEntidad RetornarCliente(String dni)
        {
            SqlCommand cmd = null;
            ClienteEntidad cliente = new ClienteEntidad();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_retornaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("clienteDNI", dni);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                cliente.clienteID = Convert.ToInt16(dr["clienteID"]);
                cliente.cliente_nombres = dr["cliente_nombres"].ToString();
                cliente.cliente_apellidos = dr["cliente_apellidos"].ToString();
                cliente.cliente_DNI = dr["cliente_DNI"].ToString();
                cliente.cliente_direccion= dr["cliente_direccion"].ToString();
                cliente.cliente_celular= dr["cliente_celular"].ToString();
                cliente.cliente_fechanacimiento = Convert.ToDateTime(dr["cliente_fechanacimiento"]);
                cliente.cliente_activo = Convert.ToBoolean(dr["cliente_activo"]);
                
            }catch(Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return cliente;
        }


        public Boolean PoseeDeuda(int id)
        {
            SqlCommand cmd = null;
            Boolean poseedeuda = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_verificarDeuda", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("clienteID", id);
                SqlParameter outParam = new SqlParameter();
                outParam.SqlDbType = System.Data.SqlDbType.Bit;
                outParam.ParameterName = "@Result";
                outParam.Value = 0;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);
                cn.Open();
                cmd.ExecuteNonQuery();
                poseedeuda = (Boolean)cmd.Parameters["@Result"].Value;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return poseedeuda;
        }
        public Boolean ExisteCliente(String dni)
        {
            SqlCommand cmd = null;
            Boolean existe;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_verificaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("clienteDNI", dni);
                SqlParameter outParam = new SqlParameter();
                outParam.SqlDbType = System.Data.SqlDbType.Bit;
                outParam.ParameterName = "@Result";
                outParam.Value = 0;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);
                cn.Open();
                cmd.ExecuteNonQuery();
                existe = (Boolean)cmd.Parameters["@Result"].Value;
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return existe;
        }
       
        #endregion metodos
    }
}
