using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Praca_Inzynierska_PSobczak.Data;
using Praca_Inzynierska_PSobczak.Models;
using Praca_Inzynierska_PSobczak.Services;
using Praca_Inzynierska_PSobczak.ViewModels.VisitsViewModels;

namespace Praca_Inzynierska_PSobczak.Controllers
{
    [Authorize(Roles = "Admin,Client,Registar")]
    public class VisitsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DoctorService doctorService;
        private readonly VisitsService visitsService;
        private readonly UserService userService;

        public VisitsController(ApplicationDbContext context, DoctorService doctorService, VisitsService visitsService, UserService userService)
        {
            _context = context;
            this.doctorService = doctorService;
            this.visitsService = visitsService;
            this.userService = userService;
        }

        // GET: Visits
        public async Task<IActionResult> Index()
        {
            var vr = new VisitsListViewModel()
            {
                Visits = _context.Visits.Select(x => new VisitsListItemViewModel
                {
                    VisitId = x.VisitId,
                    VisitsDescription = x.VisitsDescription,
                    Doctor = x.Doctor,
                    User = x.User,
                    VisitDate = x.VisitDate
                })
            };
            return View(vr);
        }


        // GET: Visits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visits
                .FirstOrDefaultAsync(m => m.VisitId == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // GET: Visits/Create
        public IActionResult Create()
        {
            var doctor = doctorService.GetDoctorToDropdown();
            var user = userService.GetUserToDropdown();

            ViewBag.doctor = doctor.Select(y => new SelectListItem()
            {
                Text = y.FirstName + " " + y.LastName,
                Value = y.DoctorId.ToString()
            });

            ViewBag.user= user.Select(y => new SelectListItem()
            {
                Text = y.FirstName + " " + y.LastName,
                Value = y.Id.ToString()
            });

            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewVisitViewModel model)
        {
            var vr = new Visit
            {
                VisitsDescription = model.VisitsDescription,
                Doctor = model.Doctor,
                VisitDate = model.VisitDate,
                UserId = model.UserId,
                User = model.User,
                DoctorId = model.DoctorId
            };
            if (ModelState.IsValid)
            {
                _context.Visits.Add(vr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Visits");
        }

        // GET: Visits/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var vm = visitsService.GetVisit(id);
            var doctor = doctorService.GetDoctorToDropdown();
            var user = userService.GetUserToDropdown();

            ViewBag.doctor = doctor.Select(y => new SelectListItem()
            {
                Text = y.FirstName + " " + y.LastName,
                Value = y.DoctorId.ToString()
            });

            ViewBag.user = user.Select(y => new SelectListItem()
            {
                Text = y.FirstName + " " + y.LastName,
                Value = y.Id.ToString()
            });
            return View(vm);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string VisitsDescription, int doctorId, DateTime VisitDate,int userId)
        {

            visitsService.UpdateVisit(id, VisitDate, doctorId, VisitsDescription, userId);

            return RedirectToAction("Index", "Visits");

        }

        // GET: Visits/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var vm = visitsService.GetVisit(id);
            return View(vm);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            visitsService.DeleteVisit(id);
            return RedirectToAction("Index", "Visits");
        }

        private bool VisitExists(int id)
        {
            return _context.Visits.Any(e => e.VisitId == id);
        }
    }
}
