using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuarioTienda = new HashSet<UsuarioTienda>();
            ValoracionTienda = new HashSet<ValoracionTienda>();
        }

        public decimal IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string Contrasena { get; set; }
        public decimal IdRol { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        public virtual ICollection<UsuarioTienda> UsuarioTienda { get; set; }
        public virtual ICollection<ValoracionTienda> ValoracionTienda { get; set; }
    }
}
