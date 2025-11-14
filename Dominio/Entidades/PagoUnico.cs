using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PagoUnico : Pago
    {
        private DateTime _fechaPago;
        private int _numRecibo;
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
        
        public PagoUnico(DateTime fechaPago, int numRecibo, Gasto gasto, MetodoDePago metodoDePago, Usuario usuario, string descripcion, decimal monto) : base(gasto, metodoDePago, usuario, descripcion, monto)
        {
            _fechaPago = fechaPago;
            _numRecibo = numRecibo;
        }

        public override decimal CalcularMontoAjustado()
        {
            return Monto;
        }

        // aplica descuentos por metodo de pago o por existir
        public override decimal AplicarIncrementosYDescuentos(decimal montoAjustado)
        {
            decimal total = 1.10m;
            if (MetodoPago == MetodoDePago.Efectivo)
            {
                total = 1.20m;
            }
            
            return total * montoAjustado;
        }


        /*public override bool ComprobarMesDePago()
        {
            DateTime fechaActual = DateTime.Now;
            if (_fechaPago.Month >= fechaActual.Month)
             {
                 return true;
             }
               return false;
        }*/

        public override string ToString()
        {
            return $"{base.ToString()} Recibo: {_numRecibo}, Fecha de pago: {_fechaPago.Day}/{_fechaPago.Month}/{_fechaPago.Year}";
        }


    }
    
}