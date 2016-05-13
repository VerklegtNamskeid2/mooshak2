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

       public CoursesViewModel GetUserCourses(string UserID)
       {
            var usersInCourse = _db.UsersCourses.Where(x => x.UserID == UserID).ToList();
            var studentCourseIDs = usersInCourse.Where(x => x.RoleID == 1).Select(x => x.CourseID).ToList();
            var studentCourses = _db.Courses.Where(x => studentCourseIDs.Contains(x.ID)).ToList();

            var teacherCourseIDs = usersInCourse.Where(x => x.RoleID == 2).Select(x => x.CourseID).ToList();
            var teacherCourses = _db.Courses.Where(x => teacherCourseIDs.Contains(x.ID)).ToList();

            return new CoursesViewModel
            {
                CoursesTeacher = teacherCourses,
                CoursesStudent = studentCourses
            };
       }
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
                .ToList();

            var viewModel = new CoursesViewModel
            {
                Course = courses,
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