using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class ValoracionTienda
    {
        public int IdValoracion { get; set; }
        public decimal Valoracion { get; set; }
        public string Comentario { get; set; }
        public string IdUsuario { get; set; }
        public int IdTienda { get; set; }

        public virtual Tiendas Tiendas { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
