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
        public AssignmentsViewModels GetAssignmentByID(int assignmentsID)
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
                Assignment = assignments,
                Milestones = milestones
            };
            return viewModel;
        }


        public MilestonesCreateViewModels GetMilestoneByID(int milestoneID)
        {
            var milestones = _db.Milestones.SingleOrDefault(x => x.ID == milestoneID);
            if (milestones == null)
            {
                //TODO: kastavillu!
            }


            MilestonesCreateViewModels viewModel = new MilestonesCreateViewModels
            {
                Milestone = milestones
            };
            return viewModel;
        }

        public void Add(AssignmentCreateViewModel model)
        {

            _db.Assignments.Add(model.Assignment);
            _db.SaveChanges();

        }

        public void AddMilestone(MilestonesCreateViewModels model)
        {
            _db.Milestones.Add(model.Milestone);
            _db.SaveChanges();
        }

        public void AddSolution(Solution model)
        {
            _db.Solutions.Add(model);
            _db.SaveChanges();
                    

        }

        public void AddMilestoneIO(MilestonesIOViewModels model)
        {
            _db.InputOutput.Add(model.MilestoneIO);
            _db.SaveChanges();
        }
    }
}
