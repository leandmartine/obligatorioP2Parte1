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

        public Pago(MetodoDePago MetodoPago, Gasto Gasto, Usuario Usuario, string Descripcion)
        {
            _id = s_ultimoId++;
            _metodoPago = MetodoPago;
            _gasto = Gasto;
            _usuario = Usuario;
            _descripcion = Descripcion;
        }

        public override string ToString()
        {
            return $"Pago #{Id}";
        }
    }
}