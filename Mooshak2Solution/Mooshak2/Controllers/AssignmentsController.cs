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
using System.Diagnostics;
using Microsoft.AspNet.Identity;

using System.IO;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace Mooshak2.Controllers
{
    public class AssignmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private AssignmentsServices _service = new AssignmentsServices();
        private CoursesServices _courseservice = new CoursesServices();

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

            var obj = _service.GetAssignmentByID((int)id);
            var isTeacher = _courseservice.GetCourseByID(obj.Assignment.CourseID);
            ViewBag.model = obj;
            ViewBag.isTeacher = isTeacher;
            var solutions = _service.GetHistoryForAssignment(obj.Assignment.ID, User.Identity.GetUserId());
            ViewBag.solutions = solutions;
            return View();
        }

        // GET: Assignments/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewmodel = _courseservice.GetUserCourses(User.Identity.GetUserId());
            if (viewmodel.CoursesTeacher.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);

            }
            ViewBag.Courses = from row in viewmodel.CoursesTeacher
                             select new SelectListItem
                             {
                                 Text = row.Title.ToString(),
                                 Value = row.ID.ToString()
                             };
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [Authorize]
        public ActionResult Create(AssignmentCreateViewModel model)
        {
            model.Assignment.CourseID = model.CourseID;
            _service.Add(model);

            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "Assignments", action = "Details", Id = model.Assignment.ID }));
        }

        /* [HttpGet]
         public ActionResult Create()
         {
             return RedirectToAction("CreateMilestoneTest");
             //return View();
         }*/

        [HttpPost]
        public ActionResult CreateMilestone(MilestonesCreateViewModels model)
        {
            _service.AddMilestone(model);

            return RedirectToAction("Details", new RouteValueDictionary(new { controller = "Assignments", action = "Details", Id = model.Milestone.AssignmentID} ));
        }

        [HttpGet]
        public ActionResult CreateMilestone(int id)
        {
            ViewBag.assignmentID = id;
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

        //GET:/Assignment/MilestoneAddIO/5/
        [HttpGet]
        public ActionResult MilestoneAddIO(int id)//(int? milestoneID)
        {
            var milestone = _service.GetMilestoneByID(id);
            ViewBag.milestone = milestone;

            return View();
        }

        //POST:/Assignment/MilestoneAddIO/5/
        
        [HttpPost]
        public ActionResult MilestoneAddIO(MilestonesIOViewModels model)
        {
            _service.AddMilestoneIO(model);
            return View();
        }

        [HttpGet]
        public ActionResult MilestoneDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.milestone = _service.GetMilestoneByID((int)id);
            return View();
        }

        [HttpPost]
        public ActionResult MilestoneDetail(MilestoneSubmitViewModels model)
        {
            //
            // var numberTried = 
            //
            var workingFolder = "C:\\Temp\\Moostache\\";
            Random rand = new Random();
            var id = rand.Next(1000, 99999);
            var cppFileName = id.ToString() + "Hello.cpp";
            var exeFilePath = workingFolder + id.ToString() + "Hello.exe";

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(workingFolder, cppFileName);
                    file.SaveAs(path);
                }
            }

            // In this case, we use the C++ compiler (cl.exe) which ships
            // with Visual Studio. It is located in this folder:
            var compilerFolder = "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\VC\\bin\\";
            // There is a bit more to executing the compiler than
            // just calling cl.exe. In order for it to be able to know
            // where to find #include-d files (such as <iostream>),
            // we need to add certain folders to the PATH.
            // There is a .bat file which does that, and it is
            // located in the same folder as cl.exe, so we need to execute
            // that .bat file first.

            // Using this approach means that:
            // * the computer running our web application must have
            //   Visual Studio installed. This is an assumption we can
            //   make in this project.
            // * Hardcoding the path to the compiler is not an optimal
            //   solution. A better approach is to store the path in
            //   web.config, and access that value using ConfigurationManager.AppSettings.

            // Execute the compiler:
            Process compiler = new Process();
            compiler.StartInfo.FileName = "cmd.exe";
            compiler.StartInfo.WorkingDirectory = workingFolder;
            compiler.StartInfo.RedirectStandardInput = true;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.UseShellExecute = false;

            compiler.Start();
            compiler.StandardInput.WriteLine("\"" + compilerFolder + "vcvars32.bat" + "\"");
            compiler.StandardInput.WriteLine("cl.exe /nologo /EHsc " + cppFileName);
            compiler.StandardInput.WriteLine("exit");
            string output = compiler.StandardOutput.ReadToEnd();
            compiler.WaitForExit();
            compiler.Close();

            // Check if the compile succeeded, and if it did,
            // we try to execute the code:

            int numCorrect = 0;
            var InputOutputs = _service.GetMilestoneInputOutputs(1);
            int numIOs = InputOutputs.Count;

            if (System.IO.File.Exists(exeFilePath))
            {
                foreach (var io in InputOutputs)
                {
                    var processInfoExe = new ProcessStartInfo(exeFilePath, "");

                    processInfoExe.UseShellExecute = false;
                    processInfoExe.RedirectStandardInput = true;
                    processInfoExe.RedirectStandardOutput = true;
                    processInfoExe.RedirectStandardError = true;
                    processInfoExe.CreateNoWindow = true;

                    using (var processExe = new Process())
                    {
                        processExe.StartInfo = processInfoExe;
                        processExe.Start();
                        processExe.StandardInput.WriteLine(io.Input);

                        // In this example, we don't try to pass any input
                        // to the program, but that is of course also
                        // necessary. We would do that here, using
                        // processExe.StandardInput.WriteLine(), similar
                        // to above.

                        // We then read the output of the program:
                        try {
                            string check = processExe.StandardOutput.ReadLine();
                            if (check.CompareTo(io.Output) == 0)
                            {
                                numCorrect++;
                            }
                        }
                        catch (Exception) { }
                    }
                }
            }
            double correctNess = 1;
            if (numIOs != 0)
            {
                correctNess = numCorrect / (double)numIOs;
            }

            var sol = new Solution
            {
                correctness = correctNess,
                UserID = User.Identity.GetUserId(),
                MilestoneID = model.MilestoneID
            };
            _service.AddSolution(sol);
            // TODO: We might want to clean up after the process, there
            // may be files we should delete etc.
            ViewBag.correct = correctNess;
            ViewBag.submitted = true;
            var obj = _service.GetMilestoneByID(model.MilestoneID);
            ViewBag.milestone = obj;
            return View();
        }
    }
}
