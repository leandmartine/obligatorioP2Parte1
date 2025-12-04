using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public abstract class PagoRecurrente
    {
        private DateTime _fechaDesde;
        private DateTime _fechaHasta;
        private int _cuotas;
        private decimal _monto;

        public DateTime FechaDesde
        {
            get { return _fechaDesde; }
            set { _fechaDesde = value; }
        }

        public DateTime FechaHasta
        {
            get { return _fechaHasta; }
            set { _fechaHasta = value; }
        }

        public int Cuotas
        {
            get { return _cuotas; }
            set { _cuotas = value; }
        }

        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
    }
}

