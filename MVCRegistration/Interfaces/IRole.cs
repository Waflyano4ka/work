using MVCRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRegistration.Interfaces
{
    interface IRole
    {
        IEnumerable<Role> AllRoles { get; }
        Role GetRole(int UserId);
    }
}
