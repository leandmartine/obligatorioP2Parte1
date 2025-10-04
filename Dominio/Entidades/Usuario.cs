using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _contrasenha;
        private string _mail;
        private Equipo _equipo;
        private DateTime _fechaIng;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Contrasenha
        {
            get { return _contrasenha; }
            set { _apellido = value; }
        }
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        public Equipo Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }
        public DateTime FechaIng
        {
            get { return _fechaIng; }
            set { _fechaIng = value; }
        }
        public Usuario(string nombre, string apellido, string contrasenha, Equipo equipo, DateTime fechaIng)
        {
            _nombre = nombre;
            _apellido = apellido;
            _contrasenha = contrasenha;
            _mail = mail;
            Equipo = equipo;
            _fechaIng = FechaIng;
        }

        public void ValidarUsuario()
        {
            if(string.IsNullOrEmpty(_nombre)){
                throw new Exception("El nombre no puede estar vacio");
            }
            if(string.IsNullOrEmpty(_apellido)){
                throw new Exception("El apellido no puede estar vacio");
            }
            if(string.IsNullOrEmpty(_contrasenha) || _contrasenha.Length < 8){
                throw new Exception("La contraseña no puede estar vacia y debe tener al menos 8 caracteres");
            }
            }
            if(_equipo == null){
                throw new Exception("El usuario debe pertenecer a un equipo");
            }
            if(_fechaIng >= DateTime.Now){
                throw new Exception("La fecha de ingreso no puede ser mayor a la fecha actual");
            }
        }

        public string GenerarMail(){
            string mail = ""
            int contadorNombre = 0;
            int contadorApellido = 0;
            
            while(contadorNombre < 3 && _nombre.Length != contadorNombre){
                mail += _nombre[contadorNombre]; 
                contadorNombre++;
                }

            while(contadorApellido < 3 && _apellido.Length != contadorApellido){
                mail += _apellido[contadorApellido]; 
                contadorApellido++;
            }
            return mail;
            }

            // preguntar a profe si es necesario ya que agregamos a la lista en el sistema
            public void AgregarMail(string mail){
                _mail = mail;
            }

    }
}
