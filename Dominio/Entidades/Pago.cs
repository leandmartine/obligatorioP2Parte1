using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public abstract class Pago
    {
        private static int s_ultimoId = 1;
        private int _id;
        private MetodoDePago _metodoPago;
        private Gasto _gasto;
        private Usuario _usuario;
        private string _descripcion;
        private decimal _monto;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public MetodoDePago MetodoPago
        {
            get { return _metodoPago; }
            set { _metodoPago = value; }
        }

        public Gasto Gasto
        {
            get { return _gasto; }
            set { _gasto = value; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public Pago(Gasto gasto, MetodoDePago metodoPago, Usuario usuario, string descripcion, decimal monto)
        {
            _id = s_ultimoId++;
            _metodoPago = metodoPago;
            _gasto = gasto;
            _usuario = usuario;
            _descripcion = descripcion;
            _monto = monto;
        }


        public void ValidarPago()
        {
            if (Gasto == null) throw new Exception("El gasto no tiene que estar vacio");
            if (MetodoPago == null) throw new Exception("El metodo de pago no puede ser nulo ni vacio");
            if (Usuario == null) throw new Exception("El usuario no puede ser estar vacio");
            if (Monto == null) throw new Exception("El monto no puede estar vacio");
            if (Descripcion == null) throw new Exception("La descripcion no puede estar vacia.");
            ValidarPagoRecurrente();
        }
        
        // llama a metodos polimorficos que en las calases hijas va a ser modificado y adaptado por los datos diponibles para el calulo
        public decimal CalcularMonto()
        {
            decimal montoAjustado = CalcularMontoAjustado();
            decimal totalPago = AplicarIncrementosYDescuentos(montoAjustado);
            
            return totalPago;
        }

        public abstract decimal CalcularMontoAjustado();

        public abstract decimal AplicarIncrementosYDescuentos(decimal montoAjustado);

        public virtual void ValidarPagoRecurrente()
        {
        }

        // parte de buscar pagos registrados y mostrar los correspondientes al mes acual. Queda para parte 2 del obligatorio
        /*public bool MesActualDePago()
        {
            public abstract bool ComprobarMesDePago();

            return
        }*/

        public override string ToString()
        {
            return $"Pago: #{Id} Metodo de pago: {MetodoPago}, Gasto: {Gasto.ToString()}, Usuario: {Usuario}, Descripcion: {Descripcion}, Monto total: {CalcularMonto()}.";
        }

    }
}