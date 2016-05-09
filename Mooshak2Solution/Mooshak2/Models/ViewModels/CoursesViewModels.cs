using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
    public class CoursesViewModels
    {
        public List<AssignmentsViewModels> Assignments { get; set; }
        public string Title { get; set; }

    }
}