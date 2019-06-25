using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaEntidad
{
    public class ClienteEntidad
    {
        public int clienteID { get; set; }
        public String cliente_nombres { get; set; }
        public String cliente_apellidos { get; set; }
        public String cliente_DNI { get; set; }
        public DateTime cliente_fechanacimiento { get; set; }
        public String cliente_direccion { get; set; }
        public String cliente_celular { get; set; }
        public Boolean cliente_activo { get; set; }


        #region metodos
        public Boolean esClienteActivo()
        {
            return cliente_activo;
        } 

        #endregion metodos
    }
}
