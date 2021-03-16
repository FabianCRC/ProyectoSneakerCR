using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class CategoriaProductos
    {
        public CategoriaProductos()
        {
            Productos = new HashSet<Productos>();
        }

        public decimal IdCategoria { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
