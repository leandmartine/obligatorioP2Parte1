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
 
        public int Id
        {
            get { return _id; }
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
 
        public Gasto(string nombre, string descripcion)
        {
            _id = s_ultimoId++;
            _nombre = nombre;
            _descripcion = descripcion;
        }
 
        public void ValidarGasto()

        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre es obligatorio.");
            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La descripcion es obligatoria.");
        }
        
 
        public override string ToString()
        {
            return $"{_id} - {_nombre} - Descripcion:{_descripcion}";
        }

    }

}