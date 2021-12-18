using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Entities
{
    public class Stock : Entity<long>
    {
        public long ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public Stock() { }
    }
}
