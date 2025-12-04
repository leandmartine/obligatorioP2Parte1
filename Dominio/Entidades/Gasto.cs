using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;
 
namespace Dominio.Entidades

{

    public class Gasto

    {

        private static int s_ultimoId = 1;
        private int _id;
        private string _nombre;
        private string _descripcion;
        private bool _eliminado;
 
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

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public bool Eliminado
        {
            get { return _eliminado; }
        }
 
        public Gasto(string nombre, string descripcion)
        {
            _id = s_ultimoId++;
            _nombre = nombre;
            _descripcion = descripcion;
            _eliminado = false;
        }

        public Gasto()
        {
            _id = s_ultimoId++;
            _eliminado = false;
        }

 
        public void ValidarGasto()

        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre es obligatorio.");
            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La descripcion es obligatoria.");
        }
        
        public void EliminarGasto()
        {
            _eliminado = true;
        }
        
        public override bool Equals(object obj)
        {
            Gasto g = obj as Gasto;
            return g != null && _nombre.ToLower().Equals(g._nombre.ToLower()) && _eliminado == false;
        }
        
        public override string ToString()
        {
            return $"{_id} - {_nombre} - Descripcion:{_descripcion}";
        }

    }

}