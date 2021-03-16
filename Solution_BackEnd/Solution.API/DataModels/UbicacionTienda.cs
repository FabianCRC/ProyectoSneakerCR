using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class UbicacionTienda
    {
        public decimal IdUbicacion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Direccion { get; set; }
        public decimal IdTienda { get; set; }

  //      public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}
