using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class Solution
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        //public int userID { get; set; }

        [ForeignKey("Milestone")]
        public int MilestoneID { get; set; }
        public virtual AssignmentMilestone Milestone { get; set; }



        public string code { get; set; }

    }
}