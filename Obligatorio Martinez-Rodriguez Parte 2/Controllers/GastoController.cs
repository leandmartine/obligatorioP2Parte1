using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio_Martinez_Rodriguez_Parte_2.Controllers;

public class GastoController : Controller
{

    Sistema sistema = Sistema.Instancia;
    public IActionResult MostrarGastos()
    {
        try
        {
            if (HttpContext.Session.GetString("mail") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                
                return View(sistema.Gastos);
            }
        }   catch (Exception ex)
        {
            ViewBag.mensaje = ex.Message;
            return View(sistema.Gastos);
        }
    }
    public IActionResult Eliminar(int id) 
    {
        try
        {
            if (HttpContext.Session.GetString("mail") == null)
            {
                return RedirectToAction("Index", "Login");
            }else
            {
                    Gasto gasto = sistema.BuscarGastoPorId(id);
                if (gasto != null)
                {
                    return View(gasto);
                }
                else
                {
                    ViewBag.mensaje = "El gasto no existe";
                    return View("MostrarGastos", sistema.Gastos);
                }
            }
        }
        catch (Exception ex)
        {
            ViewBag.mensaje = ex.Message;
            return View();
        }
    }

    [HttpPost]
    public IActionResult Eliminar(Gasto gasto)
    {
        try
        {
           sistema.BorrarGasto(gasto.Id);
            return RedirectToAction("MostrarGastos");
           
        }
        catch(Exception ex)
        {
            ViewBag.mensaje = ex.Message;
            return View(gasto);
        }

    }

    public IActionResult Agregar()
    {
        try
        {
            if (HttpContext.Session.GetString("mail") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        catch(Exception ex)
        {
            ViewBag.mensaje = ex.Message;
            return View("MostrarGastos", sistema.Gastos);
        }
    }

    [HttpPost]
    public IActionResult Agregar(int id, string nombre, string descripcion)
    {
        try
        {
            Gasto g = new Gasto(nombre, descripcion);
            sistema.AltaGasto(g);
            ViewBag.mensaje = "Alta exitosa";
            return View("MostrarGastos", sistema.Gastos);
        }
        catch(Exception ex)
        {
            ViewBag.mensaje = ex.Message;
            return View();
        }
    }
}