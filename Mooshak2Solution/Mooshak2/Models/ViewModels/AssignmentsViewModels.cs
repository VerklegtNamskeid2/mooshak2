using Mooshak2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Models.ViewModels
{
    public class AssignmentCreateViewModel
    {
        public virtual Assignment Assignment { get; set; }
        public int CourseID { get; set; }
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
    public class MilestonesIOViewModels
    {
        public virtual MilestoneInputOutput MilestoneIO { get; set; }
    }

    public class MilestoneSubmitViewModels
    {
        public int MilestoneID { get; set; }
        public int something { get; set; }
    }
}