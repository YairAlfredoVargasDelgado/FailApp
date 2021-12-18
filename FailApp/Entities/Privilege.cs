using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Entities
{
    public class Privilege : Entity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Privilege() { }
    }
}
