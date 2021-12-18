using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class UserPrivilegeRepository : Repository<dynamic, UserPrivileges>
    {
        public UserPrivilegeRepository(Context context) : base(context) { }

        public override UserPrivileges Map(SqlDataReader sqlDataReader)
        {
            return new UserPrivileges()
            {
                PrivilegeId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("PrivilegeId")),
                UserId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("UserID")),
            };
        }
    }
}
