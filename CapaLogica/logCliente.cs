using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logCliente
    {
        #region singleton
        private static readonly logCliente UnicaInstancia = new logCliente();
        public static logCliente Instancia
        {
            get
            {
                return logCliente.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
