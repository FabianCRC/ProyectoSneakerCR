using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution_FrontEnd.Models
{
    public partial class TelefonoTienda
    {
        public decimal IdTelefono { get; set; }
        public string Descripcion { get; set; }
        public string Numero { get; set; }
        public decimal IdTienda { get; set; }

        public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}
