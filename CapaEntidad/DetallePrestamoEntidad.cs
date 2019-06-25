using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetallePrestamoEntidad
    {
        public int detalleprestamoID { get; set; }
        public int detprestamo_nro_cuota { get; set; }
        public Double detprestamo_monto_cuota { get; set; }
        public Double detprestamo_interes { get; set; }
        public Double detprestamo_amortizacion { get; set; }
        public Double detprestamo_saldo { get; set; }        
        public PrestamoEntidad prestamoID { get; set; }
        public PagoEntidad pagoID { get; set; }




        #region metodos
        public Boolean esUltimaCuota()
        {
            return (detprestamo_nro_cuota == prestamoID.prestamo_cuotas);
        }
        #endregion metodos
    }


}
