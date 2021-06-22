using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Praca_Inzynierska_PSobczak.Models;
using Praca_Inzynierska_PSobczak.Services;
using Praca_Inzynierska_PSobczak.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Controllers
{
    public class AccountingController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly RoleService roleService;

        public AccountingController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, RoleService roleService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Register

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var usr = new User();
                usr.UserName = model.Email;
                usr.Email = model.Email;
                usr.FirstName = model.FirstName;
                usr.LastName = model.LastName;
                usr.UserType = UserType.Client;
                var result = await userManager.CreateAsync(usr, model.Password);
                await roleService.AddUserToRoleAsync(usr.Id, usr.UserType.ToString());
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

        #endregion

        #region Login&Logout


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        #endregion
    }
}
