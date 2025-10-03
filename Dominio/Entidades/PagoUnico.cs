using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public abstract class PagoUnico
    {
        private DateTime _fechaPago;
        private int _numRecibo;
        private decimal _monto;

        public DateTime FechaPago
        {
            get { return _fechaPago; }
            set { _fechaPago = value; }
        }

        public int NumRecibo
        {
            get { return _numRecibo; }
            set { _numRecibo = value; }
        }

        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
    }
}
