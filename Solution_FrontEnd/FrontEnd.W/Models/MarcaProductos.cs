using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.W.Models
{
    public partial class MarcaProductos
    {
        public MarcaProductos()
        {
            Productos = new HashSet<Productos>();
        }

        public decimal IdMarca { get; set; }
        public string MarcaProducto { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
