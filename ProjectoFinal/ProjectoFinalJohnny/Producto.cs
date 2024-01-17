using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoFinalJohnny
{
    public class Producto
    {
        //atributos
        private int _id;
        private string _descripcion;
        private double _costo;
        private double _precioVenta;
        private int _stock;
        private int _idUsuario;

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
        public string Descripcion
        {
            get 
            { 
                return this._descripcion;
            }
            set
            {
                this._descripcion = value;
            }
        }
        public double Costo
        {
            get
            {
                return this._costo;
            }
            set 
            { 
                this._costo = value; 
            }
        }
        public double PrecioVenta
        {
            get 
            { 
                return this._precioVenta;
            }
            set
            {
                this._precioVenta = value;
            }
        }
        public int Stock
        {
            get
            {
                return this._stock;
            }
            set 
            { 
                this._stock = value; 
            }
        }

        public int idUsuario
        {
            get
            {
                return this._idUsuario;
            }
            set 
            { 
                this._idUsuario = value;
            }
        }

    }


}
