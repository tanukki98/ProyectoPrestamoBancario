using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PagoEntidad
    {
        public int pagoID { get; set; }        
        public DateTime pago_fechapago { get; set; }        
        public int pago_nro_cuota { get; set; }       
        public Boolean pago_activo { get; set; }
        
    }
}
