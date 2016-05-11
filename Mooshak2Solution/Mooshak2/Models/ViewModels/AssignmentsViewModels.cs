using Mooshak2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
    public class AssignmentCreateViewModel
    {
        public virtual Assignment assignment { get; set; }
    }

    public class AssignmentsViewModels
    {
        public List<MilestonesViewModels> Milestones { get; set; }
        public string Title { get; internal set; }
    }
}