using System;
using System.Collections.Generic;

namespace Entities.models
{
    public partial class Venta
    {
        public Venta()
        {
            ProductoVendidos = new HashSet<ProductoVendido>();
        }
        public Venta( string? comentarios, int idUsuario)
        {
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }

        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<ProductoVendido> ProductoVendidos { get; set; }

        public string FullDataSale()
        {
            return $"id:{this.Id}, Comentarios:{this.Comentarios}, Id Usuario:{this.IdUsuario}";
        }
    }
}
