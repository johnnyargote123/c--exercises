using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinalJohnny.Database.Models
{
    public class Venta
    {
        //atributos
        private int _id;
        private string _comentarios;
        private int _idUsuario;

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
