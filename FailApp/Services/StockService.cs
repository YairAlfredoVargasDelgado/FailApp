using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class StockService : CRUDService<long, Stock>
    {
        public StockService(Context context): base(context) { }

        public override Stock Map(SqlDataReader sqlDataReader)
        {
            throw new NotImplementedException();
        }

        public override string Values(Stock entity)
        {
            throw new NotImplementedException();
        }
    }
}
