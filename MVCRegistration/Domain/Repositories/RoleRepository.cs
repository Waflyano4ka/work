using MVCRegistration.Interfaces;
using MVCRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRegistration.Domain.Repositories
{
    public class RoleRepository : IRole
    {
        private readonly AppDbContent appDbContent;
        public RoleRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Role> AllRoles => appDbContent.Role;

        public Role GetRole(int Id) => appDbContent.Role.FirstOrDefault(i => i.Role_ID == Id);
    }
}
