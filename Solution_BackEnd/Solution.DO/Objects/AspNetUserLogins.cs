using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
