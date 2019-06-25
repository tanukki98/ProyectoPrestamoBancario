using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAplicacion;
using CapaEntidad;
namespace ProyectoPrestamoBancario.Controllers
{
    public class RealizarPagoController : Controller
    {
       
        [HttpGet]
        public ActionResult buscarCliente()
        {
            Session["usuario"] = null;
            Session["clientebuscado"] = null;
            Session["prestamoactual"] = null;
            Session["listadetalleprestamoactual"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult buscarCliente(String dni)
        {
            Session["usuario"] = null;
            Session["clientebuscado"] = null;
            Session["prestamoactual"] = null;
            Session["listadetalleprestamoactual"] = null;
            Boolean tienedeuda = false;
            try
            {

                Boolean existe = ClienteServicio.Instancia.ExisteCliente(dni);

                if (existe)
                {
                    ClienteEntidad cliente = ClienteServicio.Instancia.RetornarCliente(dni);
                    tienedeuda = cliente.esClienteActivo() && ClienteServicio.Instancia.PoseeDeuda(cliente.clienteID);

                    if (tienedeuda)
                    {
                        Session["clientebuscado"] = cliente;
                        return RedirectToAction("mostrarPrestamo",new { id=cliente.cliente_DNI});
                    }
                    else
                    {
                        TempData["Error"] = "NOPRESTAMO";
                        return RedirectToAction("buscarCliente");
                    }

                }
                else
                {
                    TempData["Error"] = "CLIENTENOEXISTE";
                    return RedirectToAction("buscarCliente");

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public ActionResult mostrarPrestamo(String id)
        {
            try
            {
                ClienteEntidad cliente = ClienteServicio.Instancia.RetornarCliente(id);
                PrestamoEntidad prestamo = PrestamoServicio.Instancia.RetornarPrestamo(cliente.clienteID);
                List<DetallePrestamoEntidad> listadetalleprestamo = DetallePrestamoServicio.Instancia.RetornaListaDetallePrestamo(prestamo);
                DetallePrestamoEntidad cuotapagar = DetallePrestamoServicio.Instancia.RetornaCuotaAPagar(prestamo);
                return View(Tuple.Create(listadetalleprestamo,cuotapagar));
            }catch(Exception e)
            {
                throw e;
            }
        }
        public ActionResult pagarCuota(int id)
        {
            
            ClienteEntidad cliente = (ClienteEntidad)Session["clientebuscado"];
            PrestamoEntidad prestamo = PrestamoServicio.Instancia.RetornarPrestamo(cliente.clienteID);
            DetallePrestamoEntidad cuota = DetallePrestamoServicio.Instancia.RetornaDetallePrestamo(prestamo,id);
            try
            {
                Boolean pagado = DetallePrestamoServicio.Instancia.PagarCuota(cuota);
                if (pagado)
                {
                    if (!cuota.esUltimaCuota())
                    {
                        return RedirectToAction("mostrarPrestamo", new { id = cliente.cliente_DNI });
                    }
                    else
                    {
                        TempData["msj"] = "<script>alert('Todas las cuotas han sido pagadas');</script>";
                        return RedirectToAction("buscarCliente");
                    }
                    
                }
                else
                {
                    return View("Error");
                }
            }catch(Exception e)
            {
                throw e;
            }
           
        }
    }
}