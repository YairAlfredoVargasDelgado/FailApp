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
            return new Stock()
            {
                Id = sqlDataReader.GetInt32(0),
                ItemId = sqlDataReader.GetInt32(1),
                Quantity = sqlDataReader.GetDecimal(2)
            };
        }
    }
}
