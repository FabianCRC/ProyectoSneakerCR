using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
   public class CorreoTienda
    {
        public int IdCorreo { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }
        public int IdTienda { get; set; }

        public virtual Tiendas Tiendas { get; set; }
    }
}
