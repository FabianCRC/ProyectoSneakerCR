using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.W.Models
{
    public partial class UbicacionTienda
    {
        public decimal IdUbicacion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Direccion { get; set; }
        public decimal IdTienda { get; set; }

        public virtual Tiendas IdTiendaNavigation { get; set; }
    }
}
