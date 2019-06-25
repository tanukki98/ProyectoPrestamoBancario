using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PrestamoEntidad
    {
        public int prestamoID { get; set; }
        public Double monto_prestado { get; set; }
        public Double tasa_efectiva_anual { get; set; }
        public Double tasa_efectiva_mensual { get; set; }
        public Double cuota_fija_mensual { get; set; }
        public int prestamo_cuotas { get; set; }
        public DateTime prestamo_fecha { get; set; }
        public Boolean prestamo_activo { get; set; }
        public Boolean prestamo_completo { get; set; }
        public ClienteEntidad clienteID { get; set; }
        public UsuarioEntidad usuarioID { get; set; }

        #region metodos
        public Boolean MontoCorrecto()
        {
            if (monto_prestado >= 1000 && monto_prestado <= 30000)
            {
                return true;
            }
            return false;
        }
        public Boolean PorcentajeTeaCorrecto()
        {
            if (tasa_efectiva_anual >= 0.10 && tasa_efectiva_anual <= 0.20)
            {
                return true;
            }
            return false;
        }
        public Boolean NumeroCuotasCorrectas()
        {
            if (prestamo_cuotas >= 3 && prestamo_cuotas <= 24)
            {
                return true;
            }
            return false;
        }
        public void CalcularTasaEfectivaMensual()
        {
            double tem = Convert.ToDouble(1 + tasa_efectiva_anual);
            double pot = Convert.ToDouble(0.08333);
            tasa_efectiva_mensual = Math.Round((Math.Pow(tem, pot) - 1) ,2, MidpointRounding.AwayFromZero);
            
        }

        public void CalcularCuotaFijaMensual()
        {
            double i = tasa_efectiva_mensual;
            double monto = monto_prestado;
            double nrocuotas = prestamo_cuotas;
            double cuota = 0;
            cuota =Math.Round(((monto * i) / ((1 - (Math.Pow(i + 1, nrocuotas * -1))))),2, MidpointRounding.AwayFromZero);
            cuota_fija_mensual = cuota;
        }
        public Boolean VerificarPrestamo()
        {
            Boolean verifica = false;
            try
            {
                if (NumeroCuotasCorrectas() && MontoCorrecto() && PorcentajeTeaCorrecto())
                {
                    verifica = true;
                }
                return verifica;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion metodos
    }

}
