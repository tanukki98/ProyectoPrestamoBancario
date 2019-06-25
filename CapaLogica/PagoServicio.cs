using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion
{
    public class PagoServicio
    {
        #region singleton
        private static readonly PagoServicio UnicaInstancia = new PagoServicio();
        public static PagoServicio Instancia
        {
            get
            {
                return PagoServicio.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
