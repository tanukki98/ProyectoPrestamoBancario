using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entCliente
    {
        public int clienteID { get; set; }
        public String cliente_nombres { get; set; }
        public String cliente_apellidos { get; set; }
        public String cliente_DNI { get; set; }
        public Boolean cliente_activo { get; set; }

    }
}
