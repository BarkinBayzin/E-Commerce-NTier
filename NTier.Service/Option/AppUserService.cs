using NTier.Model.Entities;
using NTier.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Option
{
    public class AppUserService:BaseService<AppUser>
    {
        /// <summary>
        /// Check login credentials
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>If arguments will matched with data return true, otherwise false</returns>
        public bool CheckCredentials(string userName, string password) => Any(x => x.UserName == userName && x.Password == password);
        /// <summary>
        /// Get the User with username argument
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>User</returns>
        public AppUser FindByUsername(string userName) => GetByDefault(x => x.UserName == userName);
    }
}
