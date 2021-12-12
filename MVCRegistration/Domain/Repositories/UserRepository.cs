using MVCRegistration.Interfaces;
using MVCRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRegistration.Domain.Repositories
{
    public class UserRepository : IUser
    {
        private readonly AppDbContent appDbContent;
        public UserRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<User> AllUsers => appDbContent.User;

        public User GetUser(int Id) => appDbContent.User.FirstOrDefault(i => i.ID_User == Id);
    }
}
