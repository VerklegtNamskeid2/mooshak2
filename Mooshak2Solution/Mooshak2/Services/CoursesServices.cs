using Mooshak2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;
using Microsoft.AspNet.Identity;


namespace Mooshak2.Services
{
    public class CoursesServices
    {
        private ApplicationDbContext _db;

        public CoursesServices()
        {
            _db = new ApplicationDbContext();
        }

       // public List<CoursesViewModel> GetCourses(int courseID)
        //{
            //TODO:
            //return null;
        //}
        /* public AssignmentsViewModels GetAssignmentsByID(int assignmentsID)
         {
             var assignments = _db.Assignments.SingleOrDefault(x => x.ID == assignmentsID);
             if (assignments == null)
             {
                 //TODO: kastavillu!
             }

             var milestones = _db.Milestones
                 .Where(x => x.AssignmentID == assignmentsID)
                 .Select(x => new AssignmentsMilestonesViewModels
                 {
                     Title = x.Title
                 })
                 .ToList();

             var viewModel = new AssignmentsViewModels
             {
                 Title = assignments.Title,
                 Milestones = milestones
             };
             return viewModel;
         }
         */

        public CoursesViewModel GetCourseByID(int courseID)
        {
            var courses = _db.Courses.SingleOrDefault(x => x.ID == courseID);
            if (courses == null)
            {
                //TODO: kastavillu!
            }
            var assignments = _db.Assignments
                .Where(x => x.CourseID == courseID)
                .Select(x => new Assignment
                {
                    Title = x.Title
                })
                .ToList();

            var viewModel = new CoursesViewModel
            {
                Title = courses.Title,
                Assignments = assignments
            };
            return viewModel;
        }

        public void Add(CoursesCreateViewModel model)
        {

            _db.Courses.Add(model.course);
            _db.SaveChanges();
            /* try
             {

             }
             catch
             {

             }*/
        }

        public void AddUserToCourseTest(CourseAddUserViewModel model)
        {
            var testObject = new UsersCourse
            {
                CourseID = model.CourseID,
                UserID = model.UserID
            };

            _db.UsersCourses.Add(testObject);
            _db.SaveChanges();
        }

    }
}