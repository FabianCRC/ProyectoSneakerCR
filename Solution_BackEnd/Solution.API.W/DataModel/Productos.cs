using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.DataModel
{
    public partial class Productos
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionPproducto { get; set; }
        public decimal Anno { get; set; }
        public decimal Valor { get; set; }
        public int IdMarcaProducto { get; set; }
        public int IdTienda { get; set; }
        public int IdCategoria { get; set; }

        public virtual CategoriaProductos IdCategoriaNavigation { get; set; }
        public virtual MarcaProductos IdMarcaProductoNavigation { get; set; }
        public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}
