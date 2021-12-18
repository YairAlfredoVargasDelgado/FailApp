﻿using FailApp.Data;
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
            return new Item()
            {
                Id = sqlDataReader.GetInt32(0),
                Name = sqlDataReader.GetString(1),
                Price = sqlDataReader.GetDecimal(2),
                Description = sqlDataReader.GetString(3),
            };
        }
    }
}
