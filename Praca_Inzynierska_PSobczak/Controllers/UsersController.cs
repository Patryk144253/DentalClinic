using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Praca_Inzynierska_PSobczak.Data;
using Praca_Inzynierska_PSobczak.Models;
using Praca_Inzynierska_PSobczak.Services;
using Praca_Inzynierska_PSobczak.ViewModels.AccountViewModels;

namespace Praca_Inzynierska_PSobczak.Controllers
{
    [Authorize(Roles = "Admin,Registar")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserTypeService userTypeService;
        private readonly UserManager<User> userManager;
        private readonly RoleService roleService;

        public UsersController(ApplicationDbContext context, UserTypeService userTypeService, UserManager<User> userManager, RoleService roleService)
        {
            _context = context;
            this.userTypeService = userTypeService;
            this.userManager = userManager;
            this.roleService = roleService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var userTypes = userTypeService.getEnums();

            ViewBag.UserTypes = userTypes.Select(y => new SelectListItem()
            {
                Text = y.ToString(),
                Value = y.ToString()
            });


            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usr = new User();
                usr.UserName = model.Email;
                usr.Email = model.Email;
                usr.FirstName = model.FirstName;
                usr.LastName = model.LastName;
                usr.UserType = model.UserType;
                var result = await userManager.CreateAsync(usr, model.Password);
                await roleService.AddUserToRoleAsync(usr.Id, model.UserType.ToString());
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            var userTypes = userTypeService.getEnums();

            ViewBag.UserTypes = userTypes.Select(y => new SelectListItem()
            {
                Text = y.ToString(),
                Value = y.ToString()
            });
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Email,UserType,Password,FirstName,LastName")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
