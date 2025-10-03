using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Equipo
    {
        private static int s_ultimoId = 0;
        private int _id;
        private string _nombre;

        public int Id
        {
            get {  return _id; }
            set { _id = value; }
        }
        public string Nombre
        {
            get { return _nombre;}
            set { _nombre = value; }
        }
        
        public Equipo (string nombre)
        {
            _id = s_ultimoId++;
            _nombre = nombre;
        }
    }
}
