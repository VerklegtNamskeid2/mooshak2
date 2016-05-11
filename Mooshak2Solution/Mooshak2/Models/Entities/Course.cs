using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } 
        public string Title { get; set; }
        public ICollection<Assignment> CourseAssignments { get; set; }
    }
}
