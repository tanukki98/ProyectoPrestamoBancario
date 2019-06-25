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
    public class PrestamoDAO
    {
        #region singleton
        private static readonly PrestamoDAO UnicaInstancia = new PrestamoDAO();
        public static PrestamoDAO Instancia
        {
            get
            {
                return PrestamoDAO.UnicaInstancia;
            }

        }
        #endregion singleton
        #region metodos
        public Boolean CompletarPrestamo(int prestamoID)
        {
            SqlCommand cmd = null;
            Boolean completaprestamo = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cn.Open();


                cmd = new SqlCommand("sp_completaPrestamo", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prestamoID", prestamoID);
                




                int i = cmd.ExecuteNonQuery();
                if (i > 0) { completaprestamo = true; }


            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return completaprestamo;
        }
        public Boolean TienePrestamoActivo(String dni)
        {
            SqlCommand cmd = null;
            PrestamoEntidad prestamo = new PrestamoEntidad();
            Boolean esValidoPrestamo;
            
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_tienePrestamoActivo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("clienteDNI",dni);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    esValidoPrestamo = false;
                else
                    esValidoPrestamo = true;



            }catch(Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return esValidoPrestamo;
        }
        public PrestamoEntidad RetornarPrestamo(int clienteID)
        {
            SqlCommand cmd = null;
            PrestamoEntidad prestamo = new PrestamoEntidad();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_retornaPrestamo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("clienteID", clienteID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                prestamo.prestamoID = Convert.ToInt16(dr["prestamoID"]);
                prestamo.monto_prestado = Convert.ToDouble(dr["monto_prestado"]);
                prestamo.tasa_efectiva_anual = Convert.ToDouble(dr["tasaefec_anual"]);
                prestamo.tasa_efectiva_mensual = Convert.ToDouble(dr["tasaefec_mensual"]);
                prestamo.cuota_fija_mensual = Convert.ToDouble(dr["cuotafija_mensual"]);
                prestamo.prestamo_cuotas = Convert.ToInt16(dr["prestamo_cuotas"]);
                prestamo.prestamo_fecha = Convert.ToDateTime(dr["prestamo_fecha"]);
                prestamo.prestamo_activo = Convert.ToBoolean(dr["prestamo_activo"]);
                prestamo.prestamo_completo = Convert.ToBoolean(dr["prestamo_completo"]);
                ClienteEntidad cliente = new ClienteEntidad();
                cliente.clienteID = Convert.ToInt16(dr["clienteID"]);
                cliente.cliente_nombres = dr["cliente_nombres"].ToString();
                cliente.cliente_apellidos = dr["cliente_apellidos"].ToString();
                cliente.cliente_DNI = dr["cliente_DNI"].ToString();
                cliente.cliente_direccion = dr["cliente_direccion"].ToString();
                cliente.cliente_celular = dr["cliente_celular"].ToString();
                cliente.cliente_fechanacimiento = Convert.ToDateTime(dr["cliente_fechanacimiento"]);
                cliente.cliente_activo = Convert.ToBoolean(dr["cliente_activo"]);
                prestamo.clienteID = cliente;
                

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return prestamo;
        }
        public Boolean GuardarPrestamo(PrestamoEntidad prestamo, ref int prestamoID )
        {
            SqlCommand cmd = null;
            Boolean guardaprestamo = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_guardarPrestamo", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@monto_prestado", prestamo.monto_prestado);
                cmd.Parameters.AddWithValue("@tasaefec_anual", prestamo.tasa_efectiva_anual);
                cmd.Parameters.AddWithValue("@tasaefec_mensual", prestamo.tasa_efectiva_mensual);
                cmd.Parameters.AddWithValue("@cuotafija_mensual",prestamo.cuota_fija_mensual);
                cmd.Parameters.AddWithValue("@prestamo_cuotas",prestamo.prestamo_cuotas);
                cmd.Parameters.AddWithValue("@prestamo_fecha",prestamo.prestamo_fecha.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                cmd.Parameters.AddWithValue("@clienteID",prestamo.clienteID.clienteID);
                //cmd.Parameters.AddWithValue("@usuarioID", prestamo.usuarioID.usuarioID);
                SqlParameter outParam = new SqlParameter();
                outParam.SqlDbType = System.Data.SqlDbType.Int;
                outParam.ParameterName = "@prestamoID";
                outParam.Value = 0;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                prestamoID = (int)cmd.Parameters["@prestamoID"].Value;
                if (i > 0) { guardaprestamo = true; }
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return guardaprestamo;
        }
        #endregion metodos
    }
}
