using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFaseDos.Database.Models
{
    public class Venta
    {
        //atributos
        private int _id;
        private string _comentarios;
        private int _idUsuario;

        public Venta(string comentarios, int idUsuario)
        {
 
            _comentarios = comentarios;
            _idUsuario = idUsuario;
        }

        public Venta(int id, string comentarios, int idUsuario): this(comentarios, idUsuario)
        {
            _id = id;
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                Id = value;
            }
        }
        public string Comentarios
        {
            get
            {
                return _comentarios;
            }
            set
            {
                _comentarios = value;
            }
        }
        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }
    }
}
