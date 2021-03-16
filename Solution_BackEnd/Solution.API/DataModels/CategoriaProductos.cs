using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class CategoriaProductos
    {
        //public CategoriaProductos()
        //{
        //    Productos = new HashSet<Productos>();
        //}

        public decimal IdCategoria { get; set; }
        public string Categoria { get; set; }

        //public virtual ICollection<Productos> Productos { get; set; }
    }
}
