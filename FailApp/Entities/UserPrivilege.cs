﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Entities
{
    public class UserPrivilege : Entity<object>
    {
        public long UserId { get; set; }
        public long PrivilegeId { get; set; }
    }
}
