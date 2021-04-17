using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.W.Models
{
    public partial class UsuarioTienda
    {
        public decimal IdUsuarioTienda { get; set; }
        public string IdUsuario { get; set; }
        public decimal IdTienda { get; set; }

        public virtual Tiendas IdTiendaNavigation { get; set; }
        public virtual AspNetUsers IdUsuarioNavigation { get; set; }
    }
}
