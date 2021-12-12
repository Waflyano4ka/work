using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVCRegistration.Domain;
using MVCRegistration.Models;

namespace MVCRegistration.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContent db;
        public HomeController(AppDbContent context)
        {
            this.db = context;
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorization(string login, string password)
        {
            foreach(User user in db.User)
            {
                if (user.Login == login)
                {
                    if (user.Password == password)
                    {
                        switch (db.Role.Single(i => i.Role_ID == user.Role_ID).RoleClient) 
                        {
                             case "Администратор":
                             {
                                   return Redirect("/Home/Users");
                             }
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = db.User;
            return View(users);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(string login, string password, string name, string surname)
        {
            User user = new User();
            user.ID_User = 0;
            user.Name = name;
            user.Surname = surname;
            user.Login = login;
            user.Password = password;

            db.User.Add(user);
            await db.SaveChangesAsync();

            return Redirect("/Home/Users");
        }

        [HttpGet("Home/Users/{id}/Edit")]
        public async Task<IActionResult> UsersEdit(int id)
        {
            var itemToEdit = db.User.Single(i => i.ID_User == id);

            return View(itemToEdit);
        }

        [HttpPost("Home/Users/{id}/Edit")]
        public async Task<IActionResult> UsersEdit(int id, string login, string password, string name, string surname)
        {
            var user = db.User.Single(i => i.ID_User == id);
            user.Name = name;
            user.Surname = surname;
            user.Login = login;
            user.Password = password;

            db.User.Update(user);
            await db.SaveChangesAsync();

            return Redirect("/Home/Users");
        }

        [HttpGet("Home/Users/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var itemToRemove = db.User.Single(i => i.ID_User == id);
            db.User.Remove(itemToRemove);
            await db.SaveChangesAsync();

            return Redirect("/Home/Users");
        }
    }
}
