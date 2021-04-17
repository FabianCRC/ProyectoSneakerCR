using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class AspNetUserRoles
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRoles Role { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
