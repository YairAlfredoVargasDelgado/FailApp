using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class UserService : CRUDService<long, User>
    {
        public UserService(Context context) : base(context) { }

        public override User Map(SqlDataReader sqlDataReader)
        {
            return new User()
            {
                Id = sqlDataReader.GetInt32(0),
                Name = sqlDataReader.GetString(1),
                Password = sqlDataReader.GetString(2),
            };
        }
    }
}
