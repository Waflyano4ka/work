using Microsoft.EntityFrameworkCore;
using MVCRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRegistration.Domain
{
    public class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) { }
        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }
    }
}
