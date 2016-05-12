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
        public List<AssignmentsViewModel> GetAssignmentsInCourse(int courseID)
        {
            //TODO:
            return null;
        }
        // Sækir verkefni með assignmentID, setur alla verkefnahluta í lista.
        // Færir yfir í gagnagrunninn
        public AssignmentsViewModel GetAssignmentByID(int assignmentID)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentID);
            if (assignment == null)
            {
                //TODO: kastavillu!
            }

            var milestones = _db.Milestones
                .Where(x => x.AssignmentID == assignmentID)
                .ToList();

            AssignmentsViewModel viewModel = new AssignmentsViewModel
            {
                Assignment = assignment,
                Milestones = milestones
            };
            return viewModel;
        }


        public void Add(AssignmentCreateViewModel model)
        {

            _db.Assignments.Add(model.Assignment);
            _db.SaveChanges();

        }

        public void AddMilestone(MilestonesCreateViewModel model)
        {
            _db.Milestones.Add(model.Milestone);
            _db.SaveChanges();
        }

        public void AddSolution(Solution model)
        {
            _db.Solutions.Add(model);
            _db.SaveChanges();
                    

        }
    }
}
