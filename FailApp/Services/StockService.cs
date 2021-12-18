using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class StockService : CRUDService<long, Stock>
    {
        public void Delete(Stock e)
        {
            throw new NotImplementedException();
        }

        public void Delete(long key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stock> Get()
        {
            throw new NotImplementedException();
        }

        public Stock Get(long key)
        {
            throw new NotImplementedException();
        }

        public void Save(Stock e)
        {
            throw new NotImplementedException();
        }

        public void Update(Stock e)
        {
            throw new NotImplementedException();
        }
    }
}
