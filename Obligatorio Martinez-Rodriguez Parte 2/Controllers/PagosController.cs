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
                    List<Pago> listaPagos = sistema.PagosPorMail(mail);
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


        // POST: recibe datos y crea un PagoUnico de ejemplo
        [HttpPost]
        public IActionResult AgregarPago(int GastoId, MetodoDePago MetodoPago, string Descripcion, decimal Monto)
        {
            try
            {
                if (HttpContext.Session.GetString("mail") == null)
                    return RedirectToAction("Index", "Login");

                string mail = HttpContext.Session.GetString("mail");
                Usuario usuario = sistema.BuscarUsuarioPorMail(mail);
                Gasto gasto = sistema.BuscarGastoPorId(GastoId);
                if (usuario == null) throw new Exception("Usuario no encontrado en sesión.");
                if (gasto == null) throw new Exception("Gasto seleccionado no válido.");

                // Ejemplo: crear PagoUnico con Fecha actual y recibo 0
                Pago nuevoPago = new PagoUnico(DateTime.Now, 0, gasto, MetodoPago, usuario, Descripcion, Monto);
                sistema.AltaPago(nuevoPago);

                return RedirectToAction("PagosPorEmail");
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
                return View();
            }
        }
    }
}
