using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class MarcaProductos
    {
        //public MarcaProductos()
        //{
        //    Productos = new HashSet<Productos>();
        //}

        public decimal IdMarca { get; set; }
        public string MarcaProducto { get; set; }

        //public virtual ICollection<Productos> Productos { get; set; }
    }
}