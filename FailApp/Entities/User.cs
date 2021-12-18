using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Entities
{
    public class User : Entity<long>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Privilege> Privileges { get; set; }
        public User() { }
    }
}
