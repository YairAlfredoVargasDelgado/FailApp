using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class UserRepository : Repository<long, Users>
    {
        private PrivilegeRepository privilegesService;
        private UserPrivilegeRepository UserPrivilegeRepository;

        public UserRepository(
            Context context, 
            PrivilegeRepository privilegesService,
            UserPrivilegeRepository userPrivilegeRepository
            ) : base(context) {
            this.privilegesService = privilegesService;
            UserPrivilegeRepository = userPrivilegeRepository;
        }

        public override Users Map(SqlDataReader sqlDataReader)
        {
            var u = new Users()
            {
                Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                Name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name")),
                Password = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Password")),
            };
            var privileges = UserPrivilegeRepository.Get().Where(up => up.UserId == u.Id).ToList();
            u.Privileges = privilegesService.Get().Where(p => privileges.Where(_p => _p.PrivilegeId == p.Id).Any()).ToList();
            return u;
        }
    }
}
