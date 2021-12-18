using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class ItemService : CRUDService<long, Item>
    {
        private Context context;

        public ItemService(Context context) : base(context)
        {
        }

        public override Item Map(SqlDataReader sqlDataReader)
        {
            throw new NotImplementedException();
        }

        public override string Values(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
