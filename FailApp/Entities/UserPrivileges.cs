using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Entities
{
    public class UserPrivileges : Entity<object>
    {
        [Ignore]
        public override object Id {get;set;}
        public long UserId { get; set; }
        public long PrivilegeId { get; set; }
    }
}
