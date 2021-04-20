using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.API.Models
{
    public partial class ValoracionTienda
    {
        public int IdValoracion { get; set; }
        public decimal Valoracion { get; set; }
        public string Comentario { get; set; }
        public string IdUsuario { get; set; }
        public int IdTienda { get; set; }

        public virtual Tiendas IdTiendaNavigation { get; set; }
        public virtual AspNetUsers IdUsuarioNavigation { get; set; }
    }
}
