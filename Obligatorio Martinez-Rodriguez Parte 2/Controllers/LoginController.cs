using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;


namespace Obligatorio_Martinez_Rodriguez_Parte_2.Controllers
{
    public class LoginController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string mailUsuario, string passUsuario)
        {
            try
            {
                Usuario usuario = sistema.Login(mailUsuario, passUsuario);
                HttpContext.Session.SetString("mail", usuario.Mail);

                if(usuario.RolUsuario is RolDelUsuario.Gerente)
                {
                    HttpContext.Session.SetString("RolUsuario", "Gerente");
                }
                else
                {
                    HttpContext.Session.SetString("RolUsuario", "Empleado");
                }
                return RedirectToAction("PagosPorEmail", "Pagos");
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
