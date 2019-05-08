using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logPrestamo
    {
        #region singleton
        private static readonly logPrestamo UnicaInstancia = new logPrestamo();
        public static logPrestamo Instancia
        {
            get
            {
                return logPrestamo.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
