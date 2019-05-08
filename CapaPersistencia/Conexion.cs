using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia
{
    public class Conexion
    {

        #region singleton
        private static readonly Conexion UnicaInstancia = new Conexion();
        public static Conexion Instancia
        {
            get
            {
                return Conexion.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = @"Data Source=DESKTOP-O030M04\SQLEXPRESS;Initial Catalog=BDFINAL;Integrated Security=true";

            //cn.ConnectionString = @"Data Source=DESKTOP-O030M04\SQLEXPRESS;Initial Catalog=BDFINAL;Integrated Security=true";
            //cn.ConnectionString = "Data Source=.;Initial Catalog=BDFINAL;Integrated Security=true";
            cn.ConnectionString = "Data Source=192.168.200.209;Initial Catalog=Calidad_db;Integrated Security=False;Persist Security Info=True;User ID=zalo;Password=ClaseSisope123;TrustServerCertificate=True;Authentication=\"Sql Password\"";
            return cn;
        }
        public SqlConnection ConectarLocal()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=.";
            return cn;
        }
        #endregion metodos
    }
}
