using System;
using Dominio;

namespace Obligatorio_Martinez_Rodriguez_Parte1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una opcion");
            mostrarMenu();
            int.TryParse(Console.ReadLine(), out int opcion);

            try
            {
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ingrese Nombre");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Apellido");
                        string apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese Contraseña");
                        string contrasena = Console.ReadLine();
                        Console.WriteLine("Seleccione un equipo");
                        mostrarMenuEquipos();
                        Sistema sistema = new Sistema();
                        sistema.AltaUsuario(nombre, apellido, contrasena, null, null);
                        Console.Clear();
                        Console.WriteLine("Usuario dado de alta con exito");
                        break;

                    case 2:
                        break;
                }
            }
            catch
            {
                // ignored
            }
        }

        static void mostrarMenu()
        {
            Console.WriteLine("1. Alta Usuario");
        }

        static void mostrarMenuEquipos()
        {
            
        }
    }
}

