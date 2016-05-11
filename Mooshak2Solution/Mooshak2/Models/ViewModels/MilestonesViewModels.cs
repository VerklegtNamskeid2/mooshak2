using Mooshak2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
    public class MilestonesCreateViewModels
    {
        public virtual AssignmentMilestone milestone { get; set; }
    }
    public class MilestonesViewModels
    {
        public string Title { get; set; }

    }
}