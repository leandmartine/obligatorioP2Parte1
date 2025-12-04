using System.Runtime.InteropServices.JavaScript;
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
            try
            {
                if (HttpContext.Session.GetString("mail") == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                Usuario usuario = sistema.BuscarUsuarioPorMail(HttpContext.Session.GetString("mail"));
                
                return View(usuario);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
            
        }
        
        public IActionResult PerfilUsuario()
        {
            try
            {
                if (HttpContext.Session.GetString("mail") == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                Usuario usuario = sistema.BuscarUsuarioPorMail(HttpContext.Session.GetString("mail"));
                
                List<Pago> pagosDelMes = sistema.PagosDelMes(usuario.Mail, DateTime.Now);

                if (usuario.RolUsuario is RolDelUsuario.Gerente)
                {
                    List<Usuario> usuariosDelEquipo = sistema.ListarUsuariosPorEquipo(usuario.Equipo);

                    List<Pago> PagosDelMesDelEquipo = sistema.ListarPagosDelMesPorEquipo(usuario.Mail, DateTime.Now);
                    
                    ViewBag.UsuariosDelEquipo = usuariosDelEquipo;
                    ViewBag.PagoPorMes = PagosDelMesDelEquipo;
                }
                ViewBag.GastosMes = pagosDelMes;

                return View(usuario);
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult PerfilUsuario(DateTime fecha)
        {
            try
            {
                Usuario usuario = sistema.BuscarUsuarioPorMail(HttpContext.Session.GetString("mail"));
                List<Pago> PagosDelMesDelEquipo = sistema.ListarPagosDelMesPorEquipo(usuario.Mail, fecha);
                List<Usuario> usuariosDelEquipo = sistema.ListarUsuariosPorEquipo(usuario.Equipo);
                List<Pago> pagosDelMes = sistema.PagosDelMes(usuario.Mail, DateTime.Now);

                ViewBag.MesFiltrado = fecha.ToString("MM/yyyy");
                ViewBag.UsuariosDelEquipo = usuariosDelEquipo;
                ViewBag.PagoPorMes = PagosDelMesDelEquipo;
                ViewBag.GastosMes = pagosDelMes;
                return View("PerfilUsuario", usuario);

            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }

        public IActionResult UsuariosDelSistema()
        {
            try
            {
                if (HttpContext.Session.GetString("mail") == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                if (HttpContext.Session.GetString("RolUsuario") == "Empleado")
                {
                    return RedirectToAction("Index", "Usuario");
                }

                List<Usuario> usuarios = sistema.ListarUsuariosOrdenadosPorMail();
                
                ViewBag.Importancia = null;
                return View(usuarios);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost]
        public IActionResult UsuariosDelSistema(int importancia)
        {
            try
            {
                List<Usuario> usuarios = sistema.ListarUsuariosOrdenadosPorMail();
                ViewBag.Mensaje = "Seleccione un numero del 1 al 10";

                if (importancia > 10 || importancia <= 0)
                {
                    ViewBag.Importancia = null;
                    return View(usuarios);
                }
                else
                {
                    ViewBag.Importancia = importancia;
                    return View(usuarios); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
