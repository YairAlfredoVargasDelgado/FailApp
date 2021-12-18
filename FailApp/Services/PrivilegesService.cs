using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class PrivilegesService : CRUDService<long, Privilege>
    {
        public PrivilegesService(Context context) : base(context) { }

        public override Privilege Map(SqlDataReader sqlDataReader)
        {
            return new Privilege()
            {
                Id = sqlDataReader.GetInt32(0),
                Name = sqlDataReader.GetString(1),
                Description = sqlDataReader.GetString(2)
            };
        }
    }
}
