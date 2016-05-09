using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    ///<Summary>
    ///An assignmentsMilestone represents a part of an assignment.
    ///Each assignment may contain multiple milestones, 
    ///where each milestone weigt vertain percentage of the final
    ///grade of the assignment.
    ///</Summary>
    public class AssignmentMilestone
    {
        /// <summary>
        /// The database-generated unique Id of the milestone.
        /// </summary>
        public int ID { get; set; }
        ///<summary>
        ///A foreign key to the assignment.
        ///</summary>
        
        [ForeignKey("Assignments")]
        public int AssignmentID { get; set; }
        public virtual Assignment Assignments { get; set; }



        ///<summary>
        ///The title of the milestone. Example: "Part 1"
        ///</summary>
        public string Title { get; set; }
        /// <summary>
        /// Determines how much thie milestone weights in the assignment,
        /// Example: if this milestone is 15% of the grade of the assignment,
        /// the this porperty conteins the value 15.
        /// </summary>
        public int weight { get; set; }
    }
}