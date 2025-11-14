using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Equipo
    {
        private static int s_ultimoId = 1;
        private int _id;
        private string _nombre;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Equipo(string nombre)
        {
            _id = s_ultimoId++;
            _nombre = nombre;
        }
        
        public void validarEquipo()
        {
            if(string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede estar vacio");
        }

        public override string ToString()
        {
            return $"{_id} - {_nombre}";
        }
        public override bool Equals(object obj)
        {
            Equipo e = obj as Equipo;
            return e != null && _nombre.Equals(e._nombre);
        }
    }
}
