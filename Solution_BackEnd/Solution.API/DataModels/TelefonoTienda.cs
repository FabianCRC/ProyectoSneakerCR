using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class TelefonoTienda
    {
        public int IdTelefono { get; set; }
        public string Descripcion { get; set; }
        public string Numero { get; set; }
        public int IdTienda { get; set; }

        public virtual Tiendas Tiendas { get; set; }
    }
}