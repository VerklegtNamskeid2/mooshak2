using Mooshak2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshak2.Models.ViewModels
{
  
    public class CoursesCreateViewModel
    {
        public virtual Course course { get; set; }
    }

    public class CoursesViewModel
    {
        public List<Assignment> Assignments { get; set; }
        public string Title { get; internal set; }
        public virtual Course Course { get; set; }
        public List<Course> CoursesTeacher { get; set; }
        public List<Course> CoursesStudent { get; set; }
        public List<UsersCourse> UsersCourses { get; set; }
    }
        
    public class CourseAddUserViewModel
    {
        public int CourseID { get; set; }
        public string UserID   { get; set; }
    }
    
}