using System;
using System.Collections.Generic;

namespace Entities.models
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoVendidos = new HashSet<ProductoVendido>();
        }

        public Producto(string descpription, decimal costo, decimal precioVenta, int stock, int idUsuario)
        {
            this.Descripciones = descpription;
            this.Costo = costo;
            this.PrecioVenta = precioVenta; 
            this.Stock = stock;
            this.IdUsuario = idUsuario;

        }


        public int Id { get; set; }
        public string Descripciones { get; set; } = null!;
        public decimal? Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<ProductoVendido> ProductoVendidos { get; set; }


        public string FullProduct()
        {
            return $"id:{this.Id}, descripción:{this.Descripciones}, costo:{this.Costo}, precio Venta:{this.PrecioVenta}, stock:{this.Stock}";
        }
    }
}
