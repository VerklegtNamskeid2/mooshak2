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
            //TODO:
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
                .ToList();

            AssignmentsViewModels viewModel = new AssignmentsViewModels
            {
                Title = assignments.Title,
                Milestones = milestones
            };
            return viewModel;
        }
        

        public void Add(AssignmentCreateViewModel model)
        {
       
            _db.Assignments.Add(model.assignment);
            _db.SaveChanges();
          
        }

        public void AddMilestone(MilestonesCreateViewModels model)
        {
            _db.Milestones.Add(model.milestone);
            _db.SaveChanges();
        }
    }
}
