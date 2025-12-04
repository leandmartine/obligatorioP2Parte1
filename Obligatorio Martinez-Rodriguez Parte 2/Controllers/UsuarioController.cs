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
        }
        
            {
                if (HttpContext.Session.GetString("mail") == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                {
                }

                return View(usuario);
            }

        [HttpPost]
        {
            try
            {

            }
            catch (Exception e)
            {
        }

                }

    }
}
