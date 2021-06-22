using Praca_Inzynierska_PSobczak.Data;
using Praca_Inzynierska_PSobczak.Models;
using Praca_Inzynierska_PSobczak.ViewModels.VisitsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Services
{
    public class VisitsService
    {
        private readonly ApplicationDbContext _context;

        public VisitsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public VisitsListViewModel GetAllVisits()
        {
            var vm = new VisitsListViewModel
            {
                Visits = _context.Visits.Select(x => new VisitsListItemViewModel
                {
                    VisitId = x.VisitId,
                    VisitsDescription = x.VisitsDescription,
                    Doctor = x.Doctor,
                    VisitDate = x.VisitDate
                })
            };
            return vm;
        }

        public VisitsListViewModel GetAllVisitsById(string Name)
        {
            
            var vm = new VisitsListViewModel
            {
                Visits = _context.Visits.Where(y => y.User.UserName == Name).Select(x => new VisitsListItemViewModel
                {
                    VisitId = x.VisitId,
                    VisitsDescription = x.VisitsDescription,
                    Doctor = x.Doctor,
                    User = x.User,
                    VisitDate = x.VisitDate
                })
            };
            return vm;
        }


        public VisitsListItemViewModel GetVisit(int id)
        {
            var vis = _context.Visits
                .Where(b => b.VisitId == id)
                .FirstOrDefault();

            var vm = new VisitsListItemViewModel
            {
                VisitId = vis.VisitId,
                VisitsDescription = vis.VisitsDescription,
                Doctor = vis.Doctor,
                VisitDate = vis.VisitDate
            };
            return vm;
        }

        public void UpdateVisit(int id, DateTime VisitDate, int DoctorId, string VisitsDescription, int UserId)
        {
            var doctor = _context.Doctors.Find(DoctorId);

            var visUpp = _context.Visits
                .Where(b => b.VisitId == id)
                .FirstOrDefault();
            visUpp.VisitDate = VisitDate;
            visUpp.VisitsDescription = VisitsDescription;
            visUpp.DoctorId = DoctorId;
            visUpp.UserId = UserId;
            _context.Visits.Update(visUpp);
            _context.SaveChanges();
        }

        public void AddVisit(string VisitsDescription, Doctor DoctorData, DateTime VisitDate, User User)
        {
            var vis = new Models.Visit
            {
                VisitsDescription = VisitsDescription,
                Doctor = DoctorData,
                VisitDate = VisitDate,
                User = User

            };

            _context.Visits.Add(vis);
            _context.SaveChanges();
        }

        public void DeleteVisit(int id)
        {
            var vis = _context.Visits.Find(id);
            _context.Visits.Remove(vis);
            _context.SaveChanges();
        }


    }
}
