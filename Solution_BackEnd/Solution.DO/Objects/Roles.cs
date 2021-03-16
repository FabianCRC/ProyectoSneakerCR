using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public decimal IdRol { get; set; }
        public string DescripcionRol { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
