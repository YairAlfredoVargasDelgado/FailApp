using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Entities
{
    public class Entity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
