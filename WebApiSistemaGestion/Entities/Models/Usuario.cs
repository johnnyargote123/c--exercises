﻿using System;
using System.Collections.Generic;

namespace Entities.models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Productos = new HashSet<Producto>();
            Venta = new HashSet<Venta>();
        }

        public Usuario(string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.Mail = mail;
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Mail { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }

        public string FullDataUser()
        {
            return $"id:{this.Id}, nombre:{this.Nombre}, apellido:{this.Apellido}, nombre de usuario:{this.NombreUsuario}, contraseña:{this.Contraseña}, mail:{this.Mail}";
        }
    }
}
