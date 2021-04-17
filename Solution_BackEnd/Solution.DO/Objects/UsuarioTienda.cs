using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
   public class UsuarioTienda
    {
        public int IdUsuarioTienda { get; set; }
        public string IdUsuario { get; set; }
        public int IdTienda { get; set; }

        public virtual Tiendas Tiendas { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
