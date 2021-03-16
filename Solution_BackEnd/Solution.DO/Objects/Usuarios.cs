using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class Usuarios
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
