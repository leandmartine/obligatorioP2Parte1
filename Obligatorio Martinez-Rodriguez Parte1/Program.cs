namespace Obligatorio_Martinez_Rodriguez_Parte1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine('Ingrese una opcion');
            mostrarMenu();
            int opcion = int.tryParse(Console.ReadLine());


            private static void mostrarMenu(){
            Console.WriteLine('1. Alta Usuario');
            }
            try
            {
                switch(opcion)
            {
                    case 1:
                    console.clear();
                    Console.WriteLine('Ingrese Nombre');
                    string nombre = Console.ReadLine();
                    Console.WriteLine('Ingrese Apellido');
                    string apellido = Console.ReadLine();
                    Console.WriteLine('Ingrese Contraseña');
                    string contrasena = Console.ReadLine();
                    Console.WriteLine('Ingrese Equipo');
                    Sistema sistema = new Sistema();
                    sistema.AltaUsuario(nombre, apellido, contrasena, null, null, DateTime.Now);
                    console.clear();
                    Console.WriteLine('Usuario dado de alta con exito');
                    break;
                    case 2:
                        break;
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(Message.e);
            }
        }
    }
}
