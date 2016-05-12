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
using System.IO;

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

            ViewBag.model = _service.GetAssignmentByID((int)id);

            return View();
        }

        // GET: Assignments/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        public ActionResult Create(AssignmentCreateViewModel model)
        {

            _service.Add(model);

            //return RedirectToAction("CreateMilestoneTest");
            return View();
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

            return View();
        }

        [HttpGet]
        public ActionResult CreateMilestone()
        {
            /*var newBla = new Solution
            {
                userID = 1,
                code = "WORK DAMN YOU"
            };

            _service.AddSolution(newBla);
            return View();*/

            ViewBag.AssignmentID = new SelectList(db.Assignments, "ID", "Name");
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

            /*var milestoneIO = new MilestoneInputOutput
            {
                ID = 5,
            };
            */
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

            ViewBag.model = _service.GetMilestoneByID((int)id);
            return View();
        }

        [HttpPost]
        public ActionResult MilestoneDetail()
        {
            var workingFolder = "C:\\Temp\\Moostache\\";
            var cppFileName = "Hello.cpp";
            var exeFilePath = workingFolder + "Hello.exe";

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
            if (System.IO.File.Exists(exeFilePath))
            {
                var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                processInfoExe.UseShellExecute = false;
                processInfoExe.RedirectStandardOutput = true;
                processInfoExe.RedirectStandardError = true;
                processInfoExe.CreateNoWindow = true;
                using (var processExe = new Process())
                {
                    processExe.StartInfo = processInfoExe;
                    processExe.Start();
                    // In this example, we don't try to pass any input
                    // to the program, but that is of course also
                    // necessary. We would do that here, using
                    // processExe.StandardInput.WriteLine(), similar
                    // to above.

                    // We then read the output of the program:
                    var lines = new List<string>();
                    while (!processExe.StandardOutput.EndOfStream)
                    {
                        lines.Add(processExe.StandardOutput.ReadLine());
                    }

                    ViewBag.Output = lines;
                }
            }

            // TODO: We might want to clean up after the process, there
            // may be files we should delete etc.

            return View();
        }
    }
}
