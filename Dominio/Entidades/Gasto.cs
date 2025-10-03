using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Gasto
    {
        private string _nombre;
        private string _descripcion;

    public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public Gasto(string nombre, string descripcion)
        {
            _nombre = nombre;
            _descripcion = descripcion;
        }
    }
}
