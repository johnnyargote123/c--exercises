using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinalJohnny
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

        //Getters y Setters

            public int Id
            {
                get
                {
                return this._id;
                }
                set
                {
                    this._id = value;
                }
            }
            public string Nombre
            {
                get
                {
                return this._nombre;
                    }
                set
                {
                    this._nombre = value;
                }
            }
            public string Apellido
        {
            get
            {
                return this._apellido;
                }
            set
            {
                this._apellido = value;
            }
        }
            public string NombreUsuario
        {
            get
            {
                return this._nombreUsuario;
                }
            set
            {
                this._nombreUsuario = value;
            }
        }
            public string Contrasena
        {
            get
            {
                return this._contrasena;
            }
            set 
            { 
                this._contrasena = value; 
            }
        }
            public string Mail
        {
            get
            {
                return this._mail;
            }
            set 
            { 
                this._mail = value; 
            }
        }
    }
}
