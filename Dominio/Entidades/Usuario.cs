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
        public Usuario(string nombre, string apellido, string contrasenha, string mail, Equipo equipo, DateTime fechaIng)
        {
            _nombre = nombre;
            _apellido = apellido;
            _contrasenha = contrasenha;
            _mail = mail;
            Equipo = equipo;
            _fechaIng = FechaIng;
        }
    }
}
