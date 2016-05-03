using Mooshak2.Models;
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
        public list<AssignmentsViewModels> GetAssignmentsInCourse(int courseId)
        {
            //TODO:
            return null;
        }
        public AssignmentsViewModels Get AssignmentByID(int assignmentsID)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentsID);
           if (assignmnet == null)
            {
                //TODO: kastavillu!
            }

            var milestones = _db.Milestones
                .Where(x => x.AssignmensID == assignmentsID)
                .Select(x => new AssignmentsMilestonesViewModels
                {
                    Title = x.Title
                })
                .ToList();

            var viewModel = new AssignmentsViewModels;
           {
               Title = Assignments.Title
           }
            return viewModel;
        }
    }
}