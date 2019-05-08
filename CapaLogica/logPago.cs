using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logPago
    {
        #region singleton
        private static readonly logPago UnicaInstancia = new logPago();
        public static logPago Instancia
        {
            get
            {
                return logPago.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
