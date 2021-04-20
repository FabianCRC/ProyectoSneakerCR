using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.API.Models
{
    public partial class CategoriaProductos
    {
        public CategoriaProductos()
        {
            Productos = new HashSet<Productos>();
        }

        public int IdCategoria { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
