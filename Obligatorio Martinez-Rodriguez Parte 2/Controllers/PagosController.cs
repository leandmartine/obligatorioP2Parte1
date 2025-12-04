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
        
        {
            try
            {
                if (HttpContext.Session.GetString("mail") == null)
                    return RedirectToAction("Index", "Login");
            
                    string mail = HttpContext.Session.GetString("mail");
        

                }
                {
                return View();
            }
        }
    }
}
