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
using Mooshak2.Models.ViewModels;

namespace Mooshak2.Controllers
{
    public class AssignmentsController : Controller
    {
       private ApplicationDbContext db = new ApplicationDbContext();
        private AssignmentsServices _service = new AssignmentsServices();
        // GET: Assignments
        public ActionResult Index()
        {
            //var assignments = _db.Assignments.Include(a => a.Course);
            return View();
            
        }

        // GET: Assignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // GET: Assignments/Create
        public ActionResult Create()
        {
            //ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult CreateTest(AssignmentCreateViewModel model)
        {
            var openinDate = new DateTime(2016, 04, 01);
            var closeDate = new DateTime(2016, 04, 01);
            var testObject = new Assignment
            {
                Title = model.Title,
                CourseID = 1,
                Description = model.Description,
                OpeningDate = openinDate,
                ClosingDate = closeDate,
                SubmissionLimit = 3
            };
            _service.Add(testObject);

            return View();
        }

        [HttpGet]
        public ActionResult CreateTest()
        {
            return View();
        }
        // GET: Assignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", assignment.CourseID);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseID,Title")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", assignment.CourseID);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            db.Assignments.Remove(assignment);
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
