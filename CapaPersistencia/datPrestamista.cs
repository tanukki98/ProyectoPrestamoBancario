using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class datPrestamista
    {
        #region singleton
        private static readonly datPrestamista UnicaInstancia = new datPrestamista();
        public static datPrestamista Instancia
        {
            get
            {
                return datPrestamista.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
