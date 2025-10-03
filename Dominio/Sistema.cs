using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios;
        private List<Equipo> _equipos;
        private List<Pago> _pagos;
        private List<Gasto> _gastos;

        public Sistema()
        {
            _usuarios = new List<Usuario>();
            _equipos = new List<Equipo>();
            _pagos = new List<Pago>();
            _gastos = new List<Gasto>();
        }
        public List<Usuario> Usuarios
        {
            get { return new List<Usuario>(_usuarios); }
        }
        public List<Equipo> Equipos
        {
            get { return new List<Equipo>(_equipos); }
        }
        public List<Pago> Pagos
        {
            get { return new List<Pago>(_pagos); }
        }
        public List<Gasto> Gastos
        {
            get { return new List<Gasto>(_gastos); }
        }

        public void AltaEquipo()
        {

        }
    }
    
}
