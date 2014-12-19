using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRolesRepository : IUserRoles
    {
        public UserRolesRepository()
        {

        }

        public string GetUserName(string userId)
        {
            return new Random().Next(1000, 1050).ToString();
        }
    }
}
