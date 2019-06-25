using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class PagoDAO
    {
        #region singleton
        private static readonly PagoDAO UnicaInstancia = new PagoDAO();
        public static PagoDAO Instancia
        {
            get
            {
                return PagoDAO.UnicaInstancia;
            }

        }
        #endregion singleton
    }
}
