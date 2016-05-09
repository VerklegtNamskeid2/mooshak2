using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Services
{
    public class AssignmentsServices
    {
        private ApplicationDbContext _db;
        public AssignmentsServices()
        {
            _db = new ApplicationDbContext();
        }
        public List<AssignmentsViewModels> GetAssignmentsInCourse(int courseID)
        {

            return null;
        }

        public List<MooshakUserViewModel> GetMooshakUsersByCourse(int userID)
        {
            return null;
        }

        public List<AssignmentsMilestonesViewModels> GetAssignmentsMilestonesByAssignment(int AssignmentID)
        {
            return null;
        }

        public AssignmentsViewModels GetAssignmentsByID(int assignmentsID)
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
        

        public CourseViewModels GetCoursesByID(int courseID)
        {
            var courses = _db.Courses.SingleOrDefault(x => x.ID == courseID);
            if (courses == null)
            {
                //TODO: kastavillu!
            }
            var assignments = _db.Assignments
                .Where(x => x.CoursesID == courseID)
                .Select(x => new AssignmentsViewModels
                {
                    Title = x.Title
                })
                .ToList();

           var viewModel = new CourseViewModels
            {
                Title = courses.Title,
                Assignments = assignments
            };
            return viewModel;
        }
        
        public void Add(Assignment newAssignment)
        {
            _db.Assignments.Add(newAssignment);   
        }

        public MooshakUserViewModel MooshakUserByID (int UserID)
        {
            return null;
        } 


    }
}
