using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPrestamista
    {
        public int prestamistaID { get; set; }
        public String prest_nombres { get; set; }
        public String prest_apellidos { get; set; }
        public String prest_DNI { get; set; }
        public String prest_pass { get; set; }
        public Boolean prest_activo { get; set; }
    }
}
