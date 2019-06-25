using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class UsuarioServicio
    {

        #region singleton
        private static readonly UsuarioServicio UnicaInstancia = new UsuarioServicio();
        public static UsuarioServicio Instancia
        {
            get
            {
                return UsuarioServicio.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
