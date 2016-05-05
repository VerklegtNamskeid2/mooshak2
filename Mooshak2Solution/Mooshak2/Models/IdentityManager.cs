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
        /*Bool function that returns if Role exists or not*/
        public bool RoleExists(string name)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return roleManager.RoleExists(name);
        
        }
        /*If the role does not exists it it will make new one*/
        public bool CreateRole(string name)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var idResult = roleManager.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }
        /*Check out if user exists*/
        public bool UserExsists(string name)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            return userManager.FindByName(name) != null;
        }
        /*If user exists then he get user*/
        public ApplicationUser GetUser(string name)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            return userManager.FindByName(name);
        }
        /*If user does not exists it will create user*/
        public bool CreateUser(ApplicationUser user, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = userManager.Create(user, password);
            return idResult.Succeeded;
        }
        /*After he finds the user he will give them role*/
        public bool AddUserToRole(string userId, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
        /*Checks out if he has role*/
        public bool UserIsInRole(string userId, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var result = userManager.IsInRole(userId, roleName);
            return result;
        }
        /**/
        public void ClearUserRoles(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var user = userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                var r = roleManager.FindById(role.RoleId);
                userManager.RemoveFromRole(userId, r.Name);
            }
        }
        public IList<string> GetUserRoles(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var result = userManager.GetRoles(userId);
            return result;
        }
    }
}