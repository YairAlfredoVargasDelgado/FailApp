using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class ItemRepository : Repository<long, Item>
    {
        public ItemRepository(Context context) : base(context)
        {
        }

        public override Item Map(SqlDataReader sqlDataReader)
        {
            return new Item()
            {
                Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name")),
                Price = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("Price")),
                Description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Description")),
            };
        }
    }
}
