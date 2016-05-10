using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
    public class CourseViewModels
    {
        public List<AssignmentsViewModels> Assignments{ get; set; }
        public int Title { get; internal set; }
    }
}