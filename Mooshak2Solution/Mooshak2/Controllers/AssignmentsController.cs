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
        // GET: Assignme
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var viewModels = _service.GetAssignmentsByID(id);
            return View(viewModels);
        }
    }
}