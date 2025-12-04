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
        private static int s_ultimoId = 1;
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _contrasenha;
        private string _mail;
        private Equipo _equipo;
        private DateTime _fechaIng;
        private RolDelUsuario _rolUsuario;
        private bool _eliminado;
        //agregamos atributo por defensa
        private int _gradoImportancia;

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

        public RolDelUsuario RolUsuario
        {
            get { return _rolUsuario; }
            set { _rolUsuario = value; }
        }

        public bool Eliminado
        {
            get { return _eliminado; }
            set { _eliminado = value; }
        }
        
        public int GradoImportancia
        {
            get { return _gradoImportancia; }
            set { _gradoImportancia = value; }
        }

        public Usuario(string nombre, string apellido, string contrasenha, Equipo equipo, DateTime fechaIng, RolDelUsuario rolUsuario, int gradoImportancia)
        {
            _nombre = nombre;
            _apellido = apellido;
            _contrasenha = contrasenha;
            Equipo = equipo;
            _fechaIng = fechaIng;
            _rolUsuario = rolUsuario;
            _eliminado = false;
            _gradoImportancia = gradoImportancia;
        }

        public Usuario()
        {
            Id = s_ultimoId++;
            _eliminado = false;
        }

        public void ValidarUsuario()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede estar vacio");

            if (string.IsNullOrEmpty(_apellido)) throw new Exception("El apellido no puede estar vacio");

            if (string.IsNullOrEmpty(_contrasenha) || _contrasenha.Length < 8) throw new Exception("La contraseña no puede estar vacia y debe tener al menos 8 caracteres");
            
            if (_equipo == null) throw new Exception("El equipo no puede estar vacio y debe de ser una opcion valida");
            
            if (_fechaIng >= DateTime.Now)
                throw new Exception("La fecha de ingreso no puede ser mayor a la fecha actual");

            if (_rolUsuario == null) throw new Exception("El rol no puede ser nulo");
            
            if (_gradoImportancia == null) throw new Exception("El grado importancia no puede ser nulo");
        }

        // generamos mail con las primeras 3 letras del nombre y las primeras 3 del apellido. Si tiene menos agrega las que tenga. 
        public string GenerarMail()
        {
            string mail = "";
            int contadorNombre = 0;
            int contadorApellido = 0;

            while (contadorNombre < 3 && Nombre.Length != contadorNombre)
            {
                mail += _nombre[contadorNombre];
                contadorNombre++;
            }

            while (contadorApellido < 3 && _apellido.Length != contadorApellido)
            {
                mail += _apellido[contadorApellido];
                contadorApellido++;
            }

            return mail.ToLower();
        }

        // agrega mail al objeto
        public void AgregarMail(string mail)
        {
            _mail = mail;
        }

        //AGREGAR UML
        public void EliminarUsuario()
        {
            _eliminado = true;
        }

        public override bool Equals(object obj)
        {
            Usuario u = obj as Usuario;
            return u != null && _mail.Equals(u.Mail);
        }

        public override string ToString()
        {
            return $"Nombre: {_nombre}, Apellido: {_apellido}, Mail {_mail}, Equipo {_equipo}";
        }
    }

}
