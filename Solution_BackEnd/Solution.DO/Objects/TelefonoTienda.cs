using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class TelefonoTienda
    {
        public decimal IdTelefono { get; set; }
        public string Descripcion { get; set; }
        public string Numero { get; set; }
        public decimal IdTienda { get; set; }

        public virtual Tiendas Tiendas { get; set; }
    }
}
