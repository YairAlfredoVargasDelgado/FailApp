using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class StockRepository : Repository<long, Stock>
    {
        private ItemRepository ItemService;

        public StockRepository(Context context, ItemRepository itemService): base(context) {
            ItemService = itemService;
        }

        public override Stock Map(SqlDataReader sqlDataReader)
        {
            var s =  new Stock()
            {
                Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                Quantity = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("Quantity")),
                ItemId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ItemId"))
            };
            s.Item = ItemService.Get(s.ItemId);
            return s;
        }
    }
}
