using Dominio.Entidades;
namespace Dominio;

public class UsuariosOrdenadosPorMail : IComparer<Usuario>
{
        public int Compare(Usuario? x, Usuario? y)
        {
            return x.Mail.CompareTo(y.Mail) * -1;
        }
}
