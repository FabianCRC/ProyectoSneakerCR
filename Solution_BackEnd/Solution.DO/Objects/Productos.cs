using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class Productos
    {
        public decimal IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionPproducto { get; set; }
        public decimal Anno { get; set; }
        public decimal Valor { get; set; }
        public decimal IdMarcaProducto { get; set; }
        public decimal IdTienda { get; set; }
        public decimal IdCategoria { get; set; }

        public virtual CategoriaProductos CategoriaProductos { get; set; }
        public virtual MarcaProductos MarcaProductos { get; set; }
        public virtual Tiendas Tiendas { get; set; }
    }
}
