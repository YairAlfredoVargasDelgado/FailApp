using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class PrivilegeRepository : Repository<long, Privilege>
    {
        public PrivilegeRepository(Context context) : base(context) { }

        public override Privilege Map(SqlDataReader sqlDataReader)
        {
            return new Privilege()
            {
                Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name")),
                Description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Description")),
            };
        }
    }
}
