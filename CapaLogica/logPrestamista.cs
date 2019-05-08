using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logPrestamista
    {
        #region singleton
        private static readonly logPrestamista UnicaInstancia = new logPrestamista();
        public static logPrestamista Instancia
        {
            get
            {
                return logPrestamista.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
