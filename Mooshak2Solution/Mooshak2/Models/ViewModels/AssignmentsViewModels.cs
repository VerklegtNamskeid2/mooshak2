﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.ViewModels
{
    public class AssignmentsViewModels
    {
        public List<AssignmentsMilestonesViewModels> Milestones { get; set; }
        public int Title { get; internal set; }
    }
}