using Mooshak2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestAuth()
        {
            IdentityManager manager = new IdentityManager();
            if (manager.RoleExists("Administrators"))
            {
                manager.CreateRole("Administrators");
            }
            if (manager.UserExsists("Admin@admin.com"))
            {
                ApplicationUser newAdmin = new ApplicationUser();
                newAdmin.UserName = "admin@admin.com";
                manager.CreateUser(newAdmin, "123456");
            }

            var user = manager.GetUser("admin@admin.com");
            if (!manager.UserIsInRole(user.Id, "Administrators"))
            {
                manager.AddUserToRole(user.Id,"Administrators");
            }

            //var adminUserRoles = manager.GetUserRoles(User.id);

            //adminUserRoles = manager.GetUserRoles(user.Id);

            if(User.Identity.IsAuthenticated == true)
            {
                //var id = User.Identity.GetUserId();
                //var myRoles = manager.GetUserRoles(id);
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}