using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPrestamo
    {
        public int prestamoID { get; set; }
        public float monto_prestado { get; set; }
        public float TEA { get; set; }
        public float TEM { get; set; }
        public float CFM { get; set; }
        public int periodos_pago { get; set; }
        public Boolean activo { get; set; }
        public Boolean completo { get; set; }
        public entCliente clienteID { get; set; }
        public entPrestamista prestamistaID { get; set; }
    }
}
