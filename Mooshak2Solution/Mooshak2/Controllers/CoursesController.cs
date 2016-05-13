using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Services;
using Microsoft.AspNet.Identity;

using Mooshak2.Models.ViewModels;

namespace Mooshak2.Controllers
{
    public class CoursesController : Controller
    {
       private ApplicationDbContext db = new ApplicationDbContext();
        private CoursesServices _service = new CoursesServices();

        // GET: Courses
        [Authorize]
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var viewmodel = _service.GetUserCourses(userID);
            return View(viewmodel);
        }

        [Authorize]
        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _service.GetCourseByID((int)id);
            ViewBag.model = model;
            return View();
        }

        /*// GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }*/

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(CoursesCreateViewModel model)
        {
            _service.Add(model);
            
           return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DateCreated")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Manage(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manage(CourseAddUserViewModel model)
        {
            var newModel = new CourseAddUserViewModel
            {
                CourseID = 1,
                UserID = User.Identity.GetUserId(),
            };
            _service.AddUserToCourseTest(newModel);

            return Redirect("/Courses/Manage/1");
        }



    }
}
