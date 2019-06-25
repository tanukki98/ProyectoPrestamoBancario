using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaPersistencia;
namespace CapaAplicacion
{
    public class PrestamoServicio
    {
        #region singleton
        private static readonly PrestamoServicio UnicaInstancia = new PrestamoServicio();
        public static PrestamoServicio Instancia
        {
            get
            {
                return PrestamoServicio.UnicaInstancia;
            }

        }
        #endregion singleton
        #region metodos
        public Boolean CompletarPrestamo(int prestamoID)
        {
            return PrestamoDAO.Instancia.CompletarPrestamo(prestamoID);
        }
        public Boolean GuardarPrestamo(PrestamoEntidad prestamo,ref int prestamoID)
        {
            return PrestamoDAO.Instancia.GuardarPrestamo(prestamo,ref prestamoID);
        }
        public PrestamoEntidad RetornarPrestamo(int clienteID)
        {
            return PrestamoDAO.Instancia.RetornarPrestamo(clienteID);
        }

        #endregion metodos
    }
}
