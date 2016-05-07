using Mooshak2.Models.Entities;
using Mooshak2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Controllers
{
    public class AssignmentsController : Controller
    {
        private AssignmentsServices _service = new AssignmentsServices();
        
        // GET: Assignments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var viewModels = _service.GetAssignmentsByID(id);
            return View(viewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Assignment model = new Assignment();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            Assignment assignment = new Assignment();

            UpdateModel(assignment);

            _service.Add(assignment);
            //Todo að koma þessu í gagnagrunninn :/

            return RedirectToAction("Index");
        }
    }
}