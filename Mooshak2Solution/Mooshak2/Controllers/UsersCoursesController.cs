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

namespace Mooshak2.Controllers
{
    public class UsersCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UsersCourses
        public ActionResult Index()
        {
            return View(db.UsersCourses.ToList());
        }

        // GET: UsersCourses/Details/5
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersCourse usersCourse = db.UsersCourses.Find(id);
            if (usersCourse == null)
            {
                return HttpNotFound();
            }
            return View(usersCourse);
        }

        // GET: UsersCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,CourseID,RoleID")] UsersCourse usersCourse)
        {
            if (ModelState.IsValid)
            {
                db.UsersCourses.Add(usersCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usersCourse);
        }

        // GET: UsersCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersCourse usersCourse = db.UsersCourses.Find(id);
            if (usersCourse == null)
            {
                return HttpNotFound();
            }
            return View(usersCourse);
        }

        // POST: UsersCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,CourseID,RoleID")] UsersCourse usersCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersCourse);
        }

        // GET: UsersCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersCourse usersCourse = db.UsersCourses.Find(id);
            if (usersCourse == null)
            {
                return HttpNotFound();
            }
            return View(usersCourse);
        }

        // POST: UsersCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersCourse usersCourse = db.UsersCourses.Find(id);
            db.UsersCourses.Remove(usersCourse);
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
    }
}
