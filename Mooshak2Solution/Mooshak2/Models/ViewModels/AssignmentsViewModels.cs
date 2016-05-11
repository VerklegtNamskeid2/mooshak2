using Mooshak2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
    public class AssignmentCreateViewModel
    {
        public virtual Assignment Assignment { get; set; }
    }

    public class AssignmentsViewModels
    {
        public List<AssignmentMilestone> Milestones { get; set; }
        public string Title { get; internal set; }
        public virtual Assignment Assignment { get; set; }

    }
    public class MilestonesCreateViewModels
    {
        public virtual AssignmentMilestone Milestone { get; set; }
        //public string Title { get; set; }
    }
}