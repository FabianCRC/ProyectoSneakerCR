using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.DataModel
{
    public partial class CorreoTienda
    {
        public decimal IdCorreo { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }
        public decimal IdTienda { get; set; }

        public virtual Tiendas Tiendas { get; set; }
    }
}
