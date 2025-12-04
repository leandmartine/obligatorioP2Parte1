using Dominio.Entidades;

namespace Dominio
{
    public class EmpleadosDeEquipoPorMail : IComparer<Usuario>
    {
        public int Compare(Usuario? x, Usuario? y)
        {
            return x.Mail.CompareTo(y.Mail) * 1;
        }
    }
}