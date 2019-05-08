using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class datPago
    {
        #region singleton
        private static readonly datPago UnicaInstancia = new datPago();
        public static datPago Instancia
        {
            get
            {
                return datPago.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
