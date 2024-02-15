using System;
using System.Collections.Generic;

namespace Entities.models
{
    public partial class ProductoVendido
    {

        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Venta IdVentaNavigation { get; set; } = null!;

        public ProductoVendido( int stock, int idProducto, int idVenta)
        {
            Stock = stock;
            IdProducto = idProducto;
            IdVenta = idVenta;
        }

        public string FullDataProductSold()
        {
            return $"id:{this.Id}, Stock:{this.Stock}, Id Producto:{this.IdProducto}, Id Venta:{this.IdVenta}";
        }
    }


}
