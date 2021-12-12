using MVCRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRegistration.Interfaces
{
    interface IUser
    {
        IEnumerable<User> AllUsers { get; }
        User GetUser(int UserId);
    }
}
