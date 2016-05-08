using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class UsersCourse
    {
        public int ID { get; set; }
        
        public int UserID { get; set; }

        /// <summary>
        /// Need to connect this foreign key to the right table
        /// Example: [ForeignKey("UserID")]
        /// public ApplicationUser ApplicationUser { get; set; }
        /// </summary>


        public int CourseID { get; set; }

        /// <summary>
        /// Need to connect this foreign key to the right table
        /// Example: [ForeignKey("CourseID")]
        /// public Course Course { get; set; }
        /// </summary>


        public int RoleID { get; set; }
    }
}