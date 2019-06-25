using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class UsuarioEntidad
    {
        public int usuarioID { get; set; }
        public String usuario_nombre { get; set; }
        public String usuario_password { get; set; }
        public Boolean usuario_activo { get; set; }
    }
}
