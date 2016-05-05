using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models
{
    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return roleManager.RoleExists(name);

        }
        public bool CreateRole(string name)
        {
            return true;
        }
        public bool UserExsists(string name)
        {
            return true;
        }
        public ApplicationUser GetUser(string name)
        {
            return null;
        }
        public bool CreateUser(ApplicationUser user, string password)
        {
            return true;
        }
        public bool AddUserToRole(string userId, string roleName)
        {
            return true;
        }
        public bool UserIsInRole(string userId, string roleName)
        {
            return true;
        }
        public void ClearUserRoles(string userId)
        {
            
        }
        public IList<string> GetUserRoles(string userId)
        {
            return null;
        }
    }
}