using System;
using System.Collections.Generic;
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
    public class AssignmentsMilestones
    {
        /// <summary>
        /// The database-generated unique Id of the milestone.
        /// </summary>
        public int ID { get; set; }
        ///<summary>
        ///A foreign key to the assignment.
        ///</summary>
        public int AssignmentsID { get; set; }
        ///<summary>
        ///The title of the milestone. Example: "Part 1"
        ///</summary>
        public string Title { get; set; }
    }
}