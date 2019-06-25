using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaPersistencia;
namespace CapaAplicacion
{
    public class DetallePrestamoServicio
    {
        #region singleton
        private static readonly DetallePrestamoServicio UnicaInstancia = new DetallePrestamoServicio();
        public static DetallePrestamoServicio Instancia
        {
            get
            {
                return DetallePrestamoServicio.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public Boolean PagarCuota(DetallePrestamoEntidad cuota)
        {
            try
            {
                Boolean cuotaPagada = DetallePrestamoDAO.Instancia.PagarCuota(cuota);
                //LOGICA DE ULTIMA CUOTA
                if (cuotaPagada && cuota.detprestamo_nro_cuota == cuota.prestamoID.prestamo_cuotas)
                {
                    Boolean prestamocompleto = PrestamoServicio.Instancia.CompletarPrestamo(cuota.prestamoID.prestamoID);
                    if (prestamocompleto) cuotaPagada = true;
                    else throw new ArgumentException("Error al actualizar estado de prestamo"); 
                 }
                return cuotaPagada;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        public DetallePrestamoEntidad RetornaDetallePrestamo(PrestamoEntidad prestamo,int id)
        {
            return DetallePrestamoDAO.Instancia.RetornaDetallePrestamo(prestamo,id);
        }
        public DetallePrestamoEntidad RetornaCuotaAPagar(PrestamoEntidad prestamo)
        {
            return DetallePrestamoDAO.Instancia.RetornaCuotaAPagar(prestamo);
        }
        public void ActualizarLista(ref List<DetallePrestamoEntidad> listadesactualizada,PrestamoEntidad prestamo)
        {
            
            foreach (DetallePrestamoEntidad p in listadesactualizada)//ACTUALIZA EL PRESTAMO EN LA LISTA CON EL VALOR COMPLETO DE PRESTAMO
            {
                p.prestamoID = prestamo;
            }
            
        }
        public List<DetallePrestamoEntidad> RetornaListaDetallePrestamo(PrestamoEntidad prestamo)
        {
            return DetallePrestamoDAO.Instancia.RetornaListaDetallePrestamo(prestamo);
        }

        public List<DetallePrestamoEntidad> GenerarCronograma(PrestamoEntidad pr)
        {
           

            List<DetallePrestamoEntidad> listadetalleprestamo = new List<DetallePrestamoEntidad>();
            DetallePrestamoEntidad detallePrestamoAnterior = null;


            for (int x = 0; x <= pr.prestamo_cuotas; x++)
            {
                DetallePrestamoEntidad detallePrestamoExistente = null;
                
                if (x == 0)
                {
                    detallePrestamoExistente = GenerarPrimeraCuota(pr.monto_prestado);
                }
                else
                {
                    detallePrestamoExistente = GenerarCuota(x, pr.tasa_efectiva_mensual, pr.cuota_fija_mensual, detallePrestamoAnterior);
                }
                detallePrestamoExistente.prestamoID = pr;
                detallePrestamoAnterior = detallePrestamoExistente;

                listadetalleprestamo.Add(detallePrestamoExistente);
                
            }
            

            return listadetalleprestamo;
        }

        public DetallePrestamoEntidad GenerarPrimeraCuota(Double montoPrestamo)
        {

            
                DetallePrestamoEntidad primeraCuota = new DetallePrestamoEntidad();
                primeraCuota.detprestamo_monto_cuota = 0;
                primeraCuota.detprestamo_amortizacion = 0;
                primeraCuota.detprestamo_nro_cuota = 0;
                primeraCuota.detprestamo_interes = 0;
                primeraCuota.detprestamo_saldo = montoPrestamo;
            return primeraCuota;
        }
        public DetallePrestamoEntidad GenerarCuota(int nCuota,Double tasa_efectiva_mensual, Double cuota_fija_mensual, DetallePrestamoEntidad cuotaAnterior)
        {

            DetallePrestamoEntidad cuota = new DetallePrestamoEntidad();
            cuota.detprestamo_nro_cuota = nCuota;
            cuota.detprestamo_interes= Math.Round(cuotaAnterior.detprestamo_saldo * tasa_efectiva_mensual, 2, MidpointRounding.AwayFromZero);
            cuota.detprestamo_amortizacion = Math.Round(cuota_fija_mensual - cuota.detprestamo_interes, 2, MidpointRounding.AwayFromZero);
            cuota.detprestamo_saldo = Math.Round(cuotaAnterior.detprestamo_saldo - cuota.detprestamo_amortizacion, 2, MidpointRounding.AwayFromZero);
            cuota.detprestamo_monto_cuota = Math.Round(cuota_fija_mensual, 2, MidpointRounding.AwayFromZero);
            return cuota;
        }
        public Boolean GuardarDetallePrestamo(List<DetallePrestamoEntidad> listadetalleprestamo)
        {
            return DetallePrestamoDAO.Instancia.GuardarDetallePrestamo(listadetalleprestamo);
        }
        #endregion metodos
    }

}
