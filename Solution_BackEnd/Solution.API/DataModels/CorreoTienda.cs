using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class CorreoTienda
    {
        public decimal IdCorreo { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }
        public decimal IdTienda { get; set; }

        //public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}
