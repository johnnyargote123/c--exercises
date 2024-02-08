using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFaseDos.Database.Models
{
    public class Usuario
    {
        //atributos
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contrasena;
        private string _mail;


        //Constructores y sobrecarga

        public Usuario() { }


        public Usuario(string nombre, string apellido, string nombreUsuario, string password, string mail)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nombreUsuario = nombreUsuario;
            this._contrasena = password;
            this._mail = mail;
        }
        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string password, string mail) : this(nombre, apellido, nombreUsuario, password, mail)
        {
            this._id = id;
        }

        //Getters y Setters

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }
        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }
        public string Contrasena
        {
            get
            {
                return _contrasena;
            }
            set
            {
                _contrasena = value;
            }
        }
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
            }
        }


        //Metodos

        public string FullName()
        {
            return $"nombre:{this._nombre}, apellido:{this._apellido}";
        }
    }
}
