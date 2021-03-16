using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class TelefonoTienda
    {
        public decimal IdTelefono { get; set; }
        public string Descripcion { get; set; }
        public string Numero { get; set; }
        public decimal IdTienda { get; set; }

        //public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}