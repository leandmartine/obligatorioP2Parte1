using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PagoRecurrente : Pago

    {
        private DateTime _fechaDesde;
        private DateTime _fechaHasta;
        private int _cuotas;

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

       

        public PagoRecurrente(DateTime fechaDesde, DateTime fechaHasta, Gasto gasto, MetodoDePago metodoDePago, Usuario usuario, string descripcion, decimal monto) : base(gasto, metodoDePago, usuario, descripcion, monto)
        {
            _fechaDesde = fechaDesde;
            _fechaHasta = fechaHasta;
        }
        

        // tomar valor de clase padre de monto
        public override decimal CalcularMontoAjustado()
        {
            _cuotas = CalcularCuotas(FechaDesde, FechaHasta);
            if (_fechaHasta != DateTime.MinValue || _fechaHasta >= DateTime.Today)
            {
                return Monto * _cuotas;
            }
            
            return Monto;
        }

        // incrementa monto dependiendo las cuotas del pago
        public override decimal AplicarIncrementosYDescuentos(decimal montoAjustado)
        {
            decimal montoCalculado = 1.03m;
            if (_fechaHasta != DateTime.MinValue)
            {
                if (_cuotas >= 10)
                {
                    montoCalculado = 1.10m;
                }
                else if (_cuotas <= 9 && _cuotas >= 6)
                {
                    montoCalculado = 1.05m;
                }
            }
            
            return montoAjustado * montoCalculado;
        }

        public override void ValidarPagoRecurrente()
        {
            if (_fechaHasta != DateTime.MinValue)
            {
                if (_fechaHasta < _fechaDesde || _fechaDesde <= DateTime.MinValue) throw new Exception("La fecha desde debe de ser menor que la fecha hasta");
            }
        }

        // calcula cuotas pendientes
        public int CalcularCuotas(DateTime fechadesde, DateTime fechahasta)
        {
            if (fechahasta <= fechadesde)
            {
                return 0;
            }
            if (_fechaHasta != DateTime.MinValue)
            {
                TimeSpan diferencia = fechahasta - fechadesde;
                int diasDiferencia = diferencia.Days / 30;
                int cuotasPendientes = diasDiferencia;

                return cuotasPendientes;
            }

            return 0;
        }


        public override string ToString()
        {
            if (_fechaHasta != DateTime.MinValue)
            {
                return $"{base.ToString()} Cuotas pendientes: {CalcularCuotas(DateTime.Now,_fechaHasta)}";
            }
            
            return $"{base.ToString()} Pago Recurrente";
        }
        
        
    }
    
}

