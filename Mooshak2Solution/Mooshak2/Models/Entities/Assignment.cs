using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class Assignment
    {
        public int ID { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }


        /// <summary>
        /// Need to connect this foreign key to the right table
        /// Example: [ForeignKey("CoursesID")]
        /// public Course Course { get; set; }
        /// </summary>
        
        public int Title { get; set; }

        public ICollection<AssignmentMilestone> AssignmentMilestones { get; set; }
    }
}