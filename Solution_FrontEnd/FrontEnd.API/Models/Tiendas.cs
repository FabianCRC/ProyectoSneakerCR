using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.API.Models
{
    public partial class Tiendas
    {
        public Tiendas()
        {
            CorreoTienda = new HashSet<CorreoTienda>();
            Productos = new HashSet<Productos>();
            TelefonoTienda = new HashSet<TelefonoTienda>();
            UbicacionTienda = new HashSet<UbicacionTienda>();
            UsuarioTienda = new HashSet<UsuarioTienda>();
            ValoracionTienda = new HashSet<ValoracionTienda>();
        }

        public int IdTienda { get; set; }
        public string NombreTienda { get; set; }
        public string DescripcionTienda { get; set; }

        public virtual ICollection<CorreoTienda> CorreoTienda { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
        public virtual ICollection<TelefonoTienda> TelefonoTienda { get; set; }
        public virtual ICollection<UbicacionTienda> UbicacionTienda { get; set; }
        public virtual ICollection<UsuarioTienda> UsuarioTienda { get; set; }
        public virtual ICollection<ValoracionTienda> ValoracionTienda { get; set; }
    }
}
