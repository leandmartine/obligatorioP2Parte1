using System;
using Dominio;
using Dominio.Entidades;

namespace Obligatorio_Martinez_Rodriguez_Parte1
{
    internal class Program
    {
        static Sistema sistema = new Sistema();
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Ingrese una opcion");
            MostrarMenu();
            int.TryParse(Console.ReadLine(), out int opcion);
            try
            {
                bool flag = false;
                while (!flag)
                {
                    switch (opcion)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Saliendo del programa");
                            flag = true;
                            break;
                        case 1:
                            Console.Clear();
                            AltaDeUsuario();
                            Console.WriteLine("Usuario dado de alta con exito");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        //case 2:
                        //    Console.Clear();
                        //    SeleccionTipoPago();
                        //    Console.WriteLine("Pago realizado con exito.");
                        //    Console.ReadKey();
                        //    Console.Clear();
                        //    break;
                        
                        case 3:
                            Console.Clear();
                            MostrarListadoUsuarios();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        
                        case 4:
                            Console.Clear();
                            PagosPorMail();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        
                        case 5:
                            Console.Clear();
                            UsuariosPorEquipo();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("1. Alta Usuario"); // solicitud de datos para dar de alta un usuario
            //Console.WriteLine("2. Registar pago NO USAR - SE HIZO PARA VALIDAR / NO EN PRODUCCION");
            Console.WriteLine("3. Listado de todos los usuarios"); // muestra nombre, email y equipo
            Console.WriteLine("4. Listar pagos por mail de usuario"); // muestra pagos recurrentes y unicos asociados al mail de usuario, con caracteristicas id de pago, metodo, monto total
            Console.WriteLine("5. Listado de usuarios por equipo"); // muestra usuarios que pertenecen al equipo con su nombre y email
            Console.WriteLine("0. Salir"); // sale del menú

        }
        static void AltaDeUsuario()
        {
            Console.Clear();
            Console.WriteLine("Ingrese Nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            string contrasena = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Indique id de un equipo");
            MostrarMenuEquipos();
            int.TryParse(Console.ReadLine(), out int equipoSeleccionado);
            Equipo equipo = sistema.ObtenerEquipoPorId(equipoSeleccionado);
            Console.Clear();
            // creacion de objeto de usuario dado los datos que nos proporcionan
            Usuario u = new Usuario(nombre, apellido, contrasena, equipo, DateTime.Now);
            sistema.AltaUsuario(u);
            Console.WriteLine(u.ToString());
        }

        // metodo encargado de recorrer la lista de equipos y mostrar los equipos existentes al usuario
        static void MostrarMenuEquipos()
        {
            List<Equipo> equipos = sistema.Equipos;
            foreach (Equipo equipo in equipos)
            {
                Console.WriteLine(equipo.ToString());
            }
        }
        
        // recorre lista de usuarios y los muestra uno por uno
        static void MostrarListadoUsuarios()
        {
            List<Usuario> usuarios = sistema.Usuarios;
            if (usuarios.Count == 0)
            {
                Console.WriteLine("El sistema no tiene usuarios");
            }
            foreach (Usuario usuario in usuarios)
            {
                Console.WriteLine(usuario.ToString());
            }
        }

        // recorre la lista de pagos que obtiene de la lista que devuelve sistema por mail ingresado
        static void PagosPorMail()
        {
            Console.WriteLine("Ingrese mail");
            string mail = Console.ReadLine();
            List<Pago> pagosDelUsuario = sistema.PagosPorMail(mail);
            MostrarPagosPorUsuario(pagosDelUsuario);
        }
        static void MostrarPagosPorUsuario(List<Pago> pagosDelUsuario)
        {
            if (pagosDelUsuario.Count == 0)
            {
                Console.WriteLine("El usuario no tiene pagos");
            }

            foreach (Pago pago in pagosDelUsuario)
            {
                Console.WriteLine(pago.ToString());
            }
        }

        // recorre la lista que devuelve sistema de equipos y sus usuarios
        static void UsuariosPorEquipo()
        {
            Console.WriteLine("Ingrese equipo para mostrar usuarios");
            MostrarMenuEquipos();
            int.TryParse(Console.ReadLine(), out int equipoIndicado);
            Equipo e = sistema.ObtenerEquipoPorId(equipoIndicado);
            List<Usuario> usuarios = sistema.ListarUsuariosPorEquipo(e);
            MostrarListadoUsuariosPorEquipo(usuarios);
        }
        static void MostrarListadoUsuariosPorEquipo(List<Usuario> u)
        {
            if (u.Count == 0)
            {
                Console.WriteLine("El equipo no tiene usuarios");
            }
            foreach (Usuario usuario in u)
            {
                Console.WriteLine($"Nombre: {usuario.Nombre}, Apellido: {usuario.Apellido}, Mail: {usuario.Mail}");
            }
        }

        static void SeleccionTipoPago()
        {
            Console.WriteLine("Indique tipo de pago");
            Console.WriteLine("1- Pago Unico");
            Console.WriteLine("2- Pago Recurrente");
            int.TryParse(Console.ReadLine(), out int tipoPago);
            Console.WriteLine("Ingrese el mail");
            string mailUsuario = Console.ReadLine();
            Usuario us = sistema.BuscarUsuarioPorMail(mailUsuario);
            Console.WriteLine("Ingrese el tipo de gasto");
            MostrarTipoDeGasto();
            int.TryParse(Console.ReadLine(), out int gasto);
            Gasto gas = sistema.BuscarGastoPorId(gasto);
            Console.WriteLine("Ingrese metodo de pago");
            MostrarMetodosDePago();
            int.TryParse(Console.ReadLine(), out int metodoDePago);
            Console.WriteLine("Ingrese descripcion");
            string descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese monto");
            decimal.TryParse(Console.ReadLine(), out decimal monto);

            // valida el ingreso del usuario que no sea 2 o 1
            if (tipoPago != 1 && tipoPago != 2)
            {
                Console.WriteLine("Tipo de pago invalido.");
                Console.ReadKey();
            }
            else if (tipoPago == 1)
            {
                Console.WriteLine("Ingrese fecha del Pago Unico");
                DateTime fechaPago = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el numero de recibo");
                int.TryParse(Console.ReadLine(), out int numeroRecibo);
                PagoUnico pu = new PagoUnico(fechaPago, numeroRecibo, gas, 0, us, descripcion, monto);
                sistema.AltaPago(pu);
            }
            else if (tipoPago == 2)
            {
                Console.WriteLine("Ingrese la fecha del Pago Recurrente");
                DateTime fechaDesde = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese hasta que fecha es el pago, si no tiene fecha poner 0.");
                DateTime fechaHasta = DateTime.Parse(Console.ReadLine());
                PagoRecurrente pr = new PagoRecurrente(fechaDesde, fechaHasta, gas, 0, us, descripcion, monto);
                sistema.AltaPago(pr);
            }

        }

        // recorre los gastos y muestra al usuario todos los gastos
        static void MostrarTipoDeGasto()
        {
            List<Gasto> gastos = sistema.Gastos;
            if (gastos.Count == 0)
            {
                Console.WriteLine("El sistema no tiene usuarios");
            }
            foreach (Gasto gasto in gastos)
            {
                Console.WriteLine(gasto.ToString());
            }
        }
        
        static void MostrarMetodosDePago()
        {
            Console.WriteLine("0 - Credito");
            Console.WriteLine("1 - Efectivo");
            Console.WriteLine("2 - Debito");
        }


    }
}

