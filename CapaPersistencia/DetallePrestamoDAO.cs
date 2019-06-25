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
    public class DetallePrestamoDAO
    {
        #region singleton
        private static readonly DetallePrestamoDAO UnicaInstancia = new DetallePrestamoDAO();
        public static DetallePrestamoDAO Instancia
        {
            get
            {
                return DetallePrestamoDAO.UnicaInstancia;
            }

        }
        #endregion singleton


        #region metodos
        public Boolean PagarCuota(DetallePrestamoEntidad cuota)
        {
            SqlCommand cmd = null;
            Boolean pagacuota = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cn.Open();
               

                    cmd = new SqlCommand("sp_pagaCuota", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@detalleprestamoID", cuota.detalleprestamoID);
                   cmd.Parameters.AddWithValue("@nrocuota", cuota.detprestamo_nro_cuota);




                int i = cmd.ExecuteNonQuery();
                    if (i > 0) { pagacuota = true; } 
                

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return pagacuota;
        }
        public DetallePrestamoEntidad RetornaDetallePrestamo(PrestamoEntidad prestamo,int id)
        {
            SqlCommand cmd = null;
            DetallePrestamoEntidad detalleprestamo = new DetallePrestamoEntidad();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_retornaDetallePrestamo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@detalleprestamoID", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                
                    
                    detalleprestamo.detalleprestamoID = Convert.ToInt16(dr["detalleprestamoID"]);
                    detalleprestamo.detprestamo_nro_cuota = Convert.ToInt16(dr["detprest_nro_cuota"]);
                    detalleprestamo.detprestamo_monto_cuota = Convert.ToDouble(dr["detprest_monto_cuota"]);
                    detalleprestamo.detprestamo_interes = Convert.ToDouble(dr["detprest_interes"]);
                    detalleprestamo.detprestamo_amortizacion = Convert.ToDouble(dr["detprest_amortizacion"]);
                    detalleprestamo.detprestamo_saldo = Convert.ToDouble(dr["detprest_saldo"]);
                    detalleprestamo.prestamoID = prestamo;
                    
                    if (dr["pagoID"] != DBNull.Value)
                    {
                        PagoEntidad pago = new PagoEntidad();
                        pago.pagoID = Convert.ToInt16(dr["pagoID"]);
                        pago.pago_fechapago = Convert.ToDateTime(dr["pago_fechapago"]);
                        pago.pago_nro_cuota = Convert.ToInt16(dr["pago_nro_cuota"]);
                        pago.pago_activo = Convert.ToBoolean(dr["pago_activo"]);
                        detalleprestamo.pagoID = pago;

                    }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return detalleprestamo;
        }
        public DetallePrestamoEntidad RetornaCuotaAPagar(PrestamoEntidad prestamo)
        {
            SqlCommand cmd = null;
            DetallePrestamoEntidad detalleprestamo = new DetallePrestamoEntidad();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_retornaCuotaAPagar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prestamoID", prestamo.prestamoID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();


                
                detalleprestamo.detalleprestamoID = Convert.ToInt16(dr["detalleprestamoID"]);
                detalleprestamo.detprestamo_nro_cuota = Convert.ToInt16(dr["detprest_nro_cuota"]);
                detalleprestamo.detprestamo_monto_cuota = Convert.ToDouble(dr["detprest_monto_cuota"]);
                detalleprestamo.detprestamo_interes = Convert.ToDouble(dr["detprest_interes"]);
                detalleprestamo.detprestamo_amortizacion = Convert.ToDouble(dr["detprest_amortizacion"]);
                detalleprestamo.detprestamo_saldo = Convert.ToDouble(dr["detprest_saldo"]);
                detalleprestamo.prestamoID = prestamo;
                

            }catch(Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return detalleprestamo;
        }
        public List<DetallePrestamoEntidad> RetornaListaDetallePrestamo(PrestamoEntidad prestamo)
        {
            SqlCommand cmd = null;
            List<DetallePrestamoEntidad> listadetalleentidad = new List<DetallePrestamoEntidad>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_retornaListaDetallePrestamo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prestamoID", prestamo.prestamoID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DetallePrestamoEntidad detalleprestamo = new DetallePrestamoEntidad();
                    detalleprestamo.detalleprestamoID = Convert.ToInt16(dr["detalleprestamoID"]);
                    detalleprestamo.detprestamo_nro_cuota = Convert.ToInt16(dr["detprest_nro_cuota"]);
                    detalleprestamo.detprestamo_monto_cuota = Convert.ToDouble(dr["detprest_monto_cuota"]);
                    detalleprestamo.detprestamo_interes = Convert.ToDouble(dr["detprest_interes"]);
                    detalleprestamo.detprestamo_amortizacion = Convert.ToDouble(dr["detprest_amortizacion"]);
                    detalleprestamo.detprestamo_saldo = Convert.ToDouble(dr["detprest_saldo"]);
                    detalleprestamo.prestamoID = prestamo;
                    if (dr["pagoID"] != DBNull.Value)
                    {
                        PagoEntidad pago = new PagoEntidad();
                        pago.pagoID = Convert.ToInt16(dr["pagoID"]);
                        pago.pago_fechapago = Convert.ToDateTime(dr["pago_fechapago"]);                                                
                        pago.pago_nro_cuota = Convert.ToInt16(dr["pago_nro_cuota"]);
                        pago.pago_activo = Convert.ToBoolean(dr["pago_activo"]);
                        detalleprestamo.pagoID = pago;

                    }
                    
                    
                    

                    listadetalleentidad.Add(detalleprestamo);

                }
               


            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return listadetalleentidad;
        }
        public Boolean GuardarDetallePrestamo(List<DetallePrestamoEntidad> listadetalleprestamo)
        {
            SqlCommand cmd = null;
            Boolean guardadetalleprestamo = false;
            
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cn.Open();
                foreach (DetallePrestamoEntidad detalleprestamo in listadetalleprestamo)
                {
                    
                    cmd = new SqlCommand("sp_guardarDetallePrestamo", cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@detprest_nro_cuota", detalleprestamo.detprestamo_nro_cuota);
                    cmd.Parameters.AddWithValue("@detprest_monto_cuota", detalleprestamo.detprestamo_monto_cuota);
                    cmd.Parameters.AddWithValue("@detprest_interes", detalleprestamo.detprestamo_interes);
                    cmd.Parameters.AddWithValue("@detprest_amortizacion", detalleprestamo.detprestamo_amortizacion);
                    cmd.Parameters.AddWithValue("@detprest_saldo", detalleprestamo.detprestamo_saldo);
                    cmd.Parameters.AddWithValue("@prestamoID", detalleprestamo.prestamoID.prestamoID);
                  

                    
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0) { guardadetalleprestamo = true; } else { guardadetalleprestamo = false;break; }
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return guardadetalleprestamo;
        }
        #endregion metodos
    }
}
