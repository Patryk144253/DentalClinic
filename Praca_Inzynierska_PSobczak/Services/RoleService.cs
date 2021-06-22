using Microsoft.AspNetCore.Identity;
using Praca_Inzynierska_PSobczak.Data;
using Praca_Inzynierska_PSobczak.Models;
using Praca_Inzynierska_PSobczak.ViewModels.RoleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Services
{
    public class RoleService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;

        public RoleService(RoleManager<Role> _roleManager, ApplicationDbContext _context)
        {
            roleManager = _roleManager;
            context = _context;
        }

        public RoleListViewModel GetAllRoles()
        {
            var vm = new RoleListViewModel
            {
                Roles = context.Roles.Select(x => new RoleListItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };
            return vm;
        }

        public Role GetRoleById(int id)
        {
            var role = context.Roles.Find(id);

            return role;
        }

        public async Task AddUserToRoleAsync(int Id, string RoleName)
        {
            var role = await roleManager.FindByNameAsync(RoleName);
            var user = await userManager.FindByIdAsync(Id.ToString());
             await userManager.AddToRoleAsync(user, role.Name);
             
        }

        public void DeleteRole(int id)
        {
            var role = context.Roles.Find(id);
            context.Roles.Remove(role);
            context.SaveChanges();
        }


    }
}
