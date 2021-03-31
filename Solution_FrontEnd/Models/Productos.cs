using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution_FrontEnd.Models
{
    public partial class Productos
    {
        public decimal IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionPproducto { get; set; }
        public decimal Anno { get; set; }
        public decimal Valor { get; set; }
        public decimal IdMarcaProducto { get; set; }
        public decimal IdTienda { get; set; }
        public decimal IdCategoria { get; set; }

        public virtual CategoriaProductos IdCategoriaNavigation { get; set; }
        public virtual MarcaProductos IdMarcaProductoNavigation { get; set; }
        public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}
