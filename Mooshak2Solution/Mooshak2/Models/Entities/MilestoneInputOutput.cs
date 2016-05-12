using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class MilestoneInputOutput
    {
        public int ID { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        [ForeignKey("Milestone")]
        public int MilestoneID { get; set; }
        public virtual AssignmentMilestone Milestone { get; set; }
    }
}