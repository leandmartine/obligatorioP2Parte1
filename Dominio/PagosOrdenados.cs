using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio
{
    public class PagosOrdenados : IComparer<Pago>
    {
        public int Compare(Pago? x, Pago? y)
        {
            return x.Monto.CompareTo(y.Monto) * -1;
        }
    }
}
