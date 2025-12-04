using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Martinez_Rodriguez_Parte_2.Controllers
{
    public class PagosController : Controller
    {
        Sistema sistema = Sistema.Instancia;
        public IActionResult PagosPorEmail()
        {
            try
            {
                if (HttpContext.Session.GetString("mail") == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {

                    string mail = HttpContext.Session.GetString("mail");
                    List<Pago> listaPagos = sistema.PagosDelMes(mail,DateTime.Now);
                    listaPagos = sistema.PagosOrdenadosXMonto(listaPagos);
                    return View(listaPagos);
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
                return View();
            }
        }
        
        public IActionResult AgregarPago()
        {
            try
            {
                if (HttpContext.Session.GetString("mail") == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                Usuario usuario = sistema.BuscarUsuarioPorMail(HttpContext.Session.GetString("mail"));
                ViewBag.Gastos = sistema.Gastos;
                return View(usuario);
            }
            catch (Exception e)
            {
                Usuario usuario = sistema.BuscarUsuarioPorMail(HttpContext.Session.GetString("mail"));
                ViewBag.mensaje = e.Message;
                return View(usuario);
            }
           
            
        }

        [HttpPost]
        public IActionResult AgregarPago(int esRecurrente)
        {
            try
            {
                if (esRecurrente == 1)
                {
                    ViewBag.esRecurrente = true;
                    ViewBag.Gastos = sistema.Gastos;
                    return View("AgregarPagoRecurrente");
                }
                else if (esRecurrente == 0)
                {
                    ViewBag.esRecurrente = false;
                    ViewBag.Gastos = sistema.Gastos;
                    return View("AgregarPagoUnico");
                }
                else
                {
                    string mail = HttpContext.Session.GetString("mail");
                    List<Pago> listaPagos = sistema.PagosDelMes(mail,DateTime.Now);
                    listaPagos = sistema.PagosOrdenadosXMonto(listaPagos);
                    return View("PagosPorEmail", listaPagos);
                }
            }
            catch(Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }
        
        [HttpPost]
        public IActionResult AgregarPagoRecurrente(bool tieneFin, DateTime fechaHasta, DateTime fechaDesde, decimal monto, string descripcion, int idGasto, int metodoDePago)
        {
            try
            {
                Usuario usuario = sistema.BuscarUsuarioPorMail(HttpContext.Session.GetString("mail"));
                Gasto gastoDelPago = sistema.BuscarGastoPorId(idGasto);
                MetodoDePago metodoDePagoDelPago = new MetodoDePago();
                if (metodoDePago == 0)
                {
                    metodoDePagoDelPago = MetodoDePago.Credito;
                }else if (metodoDePago == 1)
                {
                    metodoDePagoDelPago = MetodoDePago.Debito;
                }else if (metodoDePago == 2)
                {
                    metodoDePagoDelPago = MetodoDePago.Efectivo;
                }
                else
                {
                    throw new Exception("Ingrese metodo de pago valido");
                }

                if (tieneFin == false)
                {
                    fechaHasta = DateTime.MinValue;
                }else if (fechaHasta == DateTime.MinValue)
                {
                    throw new Exception("Fecha fin obligatoria");
                }
                Pago pago = new PagoRecurrente(fechaDesde, fechaHasta, gastoDelPago, metodoDePagoDelPago, usuario, descripcion, monto);
                sistema.AltaPago(pago);
                
                ViewBag.mensaje = "Pago agregado correctamente";
                return View("PagoAgregadoExitosamente");
            }
            catch (Exception e)
            {
                ViewBag.Gastos = sistema.Gastos;
                ViewBag.mensaje = e.Message;
                return View();
            }
        }
        
        [HttpPost]
        public IActionResult AgregarPagoUnico(DateTime fechaPago, int numeroRecibo, decimal monto, string descripcion, int idGasto, int metodoDePago)
        {
            try
            {
                Usuario usuario = sistema.BuscarUsuarioPorMail(HttpContext.Session.GetString("mail"));
                Gasto gastoDelPago = sistema.BuscarGastoPorId(idGasto);
                MetodoDePago metodoDePagoDelPago = new MetodoDePago();
                if (metodoDePago == 0)
                {
                    metodoDePagoDelPago = MetodoDePago.Credito;
                }else if (metodoDePago == 1)
                {
                    metodoDePagoDelPago = MetodoDePago.Debito;
                }else if (metodoDePago == 2)
                {
                    metodoDePagoDelPago = MetodoDePago.Efectivo;
                }else
                {
                    throw new Exception("Ingrese metodo de pago valido");
                }
                
                Pago pago = new PagoUnico(fechaPago, numeroRecibo, gastoDelPago, metodoDePagoDelPago, usuario, descripcion, monto);
                sistema.AltaPago(pago);
                
                ViewBag.mensaje = "Pago agregado correctamente";
                return View("PagoAgregadoExitosamente");
            }
            catch (Exception e)
            {
                ViewBag.Gastos = sistema.Gastos;
                ViewBag.mensaje = e.Message;
                return View();
            }
        }
        
    }
}
