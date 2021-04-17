using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.DataModel
{
    public partial class CorreoTienda
    {
        public int IdCorreo { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }
        public int IdTienda { get; set; }

        public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}
