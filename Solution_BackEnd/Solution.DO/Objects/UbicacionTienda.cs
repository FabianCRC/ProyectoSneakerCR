using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
   public class UbicacionTienda
    {
        public decimal IdUbicacion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Direccion { get; set; }
        public decimal IdTienda { get; set; }

        public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}
