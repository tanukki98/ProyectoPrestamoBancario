using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaAplicacion;
namespace ProyectoPrestamoBancario.Controllers
{
    public class RealizarPrestamoController : Controller
    {
        // GET: RealizarPrestamo
       
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
            Boolean procede = false;
            try
            {
               
                Boolean existe = ClienteServicio.Instancia.ExisteCliente(dni);
                
                if (existe)
                {
                    ClienteEntidad cliente = ClienteServicio.Instancia.RetornarCliente(dni);
                    procede = cliente.esClienteActivo() && !ClienteServicio.Instancia.PoseeDeuda(cliente.clienteID);

                    if (procede)
                    {
                        Session["clientebuscado"] = cliente;
                        return RedirectToAction("generarCronograma");
                    }
                    else
                    {
                        
                        TempData["Error"] = "PRESTAMOACTIVO";
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
        [HttpGet]
        public ActionResult generarCronograma()
        {
            try
            {
                if (Session["clientebuscado"] != null)
                {
                    
                    return View();
                }
                else
                {
                    return View("Error");
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        [ActionName("generarCronograma")]
        public ActionResult generarCronogramaPost()
        {
            Session["prestamoactual"] = null;
            Session["listadetalleprestamoactual"] = null;
            List<DetallePrestamoEntidad> cronograma = new List<DetallePrestamoEntidad>();
            ClienteEntidad cliente = (ClienteEntidad)Session["clientebuscado"];
            PrestamoEntidad prestamo = new PrestamoEntidad();
            prestamo.clienteID = cliente;
            prestamo.monto_prestado = Double.Parse(Request.Form["prestamo_monto"]);
            prestamo.prestamo_cuotas = int.Parse(Request.Form["prestamo_nro_cuotas"]);
            prestamo.tasa_efectiva_anual = Double.Parse(Request.Form["prestamo_tea"]);
            prestamo.CalcularTasaEfectivaMensual();
            prestamo.CalcularCuotaFijaMensual();
            prestamo.prestamo_fecha = DateTime.Now;
            try
            {
                
                Boolean verificacion = prestamo.VerificarPrestamo();
                if (verificacion)
                {
                    
                    cronograma = DetallePrestamoServicio.Instancia.GenerarCronograma(prestamo);
                    Session["prestamoactual"] = prestamo;
                    Session["listadetalleprestamoactual"] = cronograma;
                    return View("generarCronograma",cronograma);
                }
                else
                {
                    return RedirectToAction("generarCronograma");
                }
                
                
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        public ActionResult guardarPrestamo()
        {
            int prestamoID=0;
            try { 
            PrestamoEntidad prestamo = (PrestamoEntidad)Session["prestamoactual"];
            List<DetallePrestamoEntidad> listaDetallePrestamo = (List<DetallePrestamoEntidad>)Session["listadetalleprestamoactual"];
            Boolean verificacionprestamo = PrestamoServicio.Instancia.GuardarPrestamo(prestamo,ref prestamoID);
            if (verificacionprestamo) { 
                    prestamo.prestamoID = prestamoID;
                  
                    DetallePrestamoServicio.Instancia.ActualizarLista(ref listaDetallePrestamo,prestamo);
                    Boolean verificaciondetalles = DetallePrestamoServicio.Instancia.GuardarDetallePrestamo(listaDetallePrestamo);
                        if(verificaciondetalles)
                        {
                            ViewBag.verificacionguardar = "TRUE";
                        }
                        else
                        {
                           ViewBag.verificacionguardar = "FALSE";
                        }
                        
                }
                else
                {
                    ViewBag.verificacionguardar = "FALSE";
                }
                return View();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
     

    }
}