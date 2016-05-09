using Mooshak2.Models;
using Mooshak2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Services
{
    public class ApplicationUserServices
    {
        private ApplicationDbContext _db;

        public ApplicationUserServices()
        {
            _db = new ApplicationDbContext();
        }

        public void AddUser(ApplicationUser newUser)
        {
            _db.Users.Add(newUser);

        }
    }
}