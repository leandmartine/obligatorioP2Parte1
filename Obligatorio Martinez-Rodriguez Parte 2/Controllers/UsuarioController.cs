using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Martinez_Rodriguez_Parte_2.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("mail") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(sistema.UsuariosActivos());
        }

        // GET: /Usuario/AgregarPago
        public IActionResult AgregarPago()
        {
            if (HttpContext.Session.GetString("mail") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string mail = HttpContext.Session.GetString("mail");
            Usuario usuario = sistema.BuscarUsuarioPorMail(mail);
            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Gastos = sistema.Gastos;
            return View(usuario);
        }

        [HttpPost]
        public IActionResult AgregarPago(int esRecurrente, decimal monto, string descripcion, string mailUsuario, int idGasto, int metodoDePago)
        {
            try
            {
                
            }
            catch(Exception e)
            {
                ViewBag.msg = e.Message;
            }
            
        }

    }
}
