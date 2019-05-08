using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class datPrestamo
    {
        #region singleton
        private static readonly datPrestamo UnicaInstancia = new datPrestamo();
        public static datPrestamo Instancia
        {
            get
            {
                return datPrestamo.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
