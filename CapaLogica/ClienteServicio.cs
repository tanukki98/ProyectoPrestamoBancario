using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia;
using CapaEntidad;
namespace CapaAplicacion
{
    public class ClienteServicio
    {
        #region singleton
        private static readonly ClienteServicio UnicaInstancia = new ClienteServicio();
        public static ClienteServicio Instancia
        {
            get
            {
                return ClienteServicio.UnicaInstancia;
            }

        }
        #endregion singleton

        
        #region metodos
        public ClienteEntidad RetornarCliente(String dni)
        {
            ClienteEntidad cliente=new ClienteEntidad();
            
            try
            {
                cliente = ClienteDAO.Instancia.RetornarCliente(dni);
                return cliente;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean ExisteCliente(String dni)
        {
            
            try
            {
                return ClienteDAO.Instancia.ExisteCliente(dni);
            }catch(Exception e) { throw e; }
        }
       
        public Boolean PoseeDeuda(int id)
        {
            return ClienteDAO.Instancia.PoseeDeuda(id);
        }
       


        //public CapaEntidad.Prestamo CalcularCronograma(CapaEntidad.Prestamo prestamos)
        //{
        //    double i = CalcularTEA(prestamos);
        //    double monto = prestamos.Monto;
        //    double nrocuotas = prestamos.NroCuotas;
        //    double cuota = CalcularCuotaFijaMensual(prestamos);

        //    CapaEntidad.Prestamo prestamo = new CapaEntidad.Prestamo();
        //    prestamo.Cliente = prestamos.Cliente;
        //    prestamo.CuotaFijaMensual = cuota;
        //    prestamo.Monto = monto;
        //    prestamo.TasaEfectiva = prestamos.TasaEfectiva;
        //    prestamo.Tea = i;

        //    List<CapaEntidad.DetPrestamo> Lista = new List<CapaEntidad.DetPrestamo>();

        //    CapaEntidad.DetPrestamo CoutaInicial = new CapaEntidad.DetPrestamo();
        //    CoutaInicial.NroCuota = 0;
        //    CoutaInicial.Saldo = monto;
        //    CoutaInicial.Amortizacion = 0;
        //    CoutaInicial.Interes = 0;
        //    CoutaInicial.MontoCouta = 0;
        //    Lista.Add(CoutaInicial);

        //    for (int x = 1; x <= nrocuotas; x++)
        //    {
        //        CapaEntidad.DetPrestamo cuotaAnterior = new CapaEntidad.DetPrestamo();
        //        cuotaAnterior = Lista[x - 1];

        //        CapaEntidad.DetPrestamo cuotaNueva = new CapaEntidad.DetPrestamo();
        //        cuotaNueva.NroCuota = x;
        //        cuotaNueva.Interes = Math.Round(cuotaAnterior.Saldo * i, 2, MidpointRounding.AwayFromZero);
        //        cuotaNueva.Amortizacion = Math.Round(cuota - cuotaNueva.Interes, 2, MidpointRounding.AwayFromZero);
        //        cuotaNueva.Saldo = Math.Round(cuotaAnterior.Saldo - cuotaNueva.Amortizacion, 2, MidpointRounding.AwayFromZero);
        //        cuotaNueva.MontoCouta = Math.Round(cuota, 2, MidpointRounding.AwayFromZero);

        //        Lista.Add(cuotaNueva);
        //    }
        //    prestamo.ListaDetPrestamo = Lista;

        //    return prestamo;
        //}
        #endregion metodos
    }

}

