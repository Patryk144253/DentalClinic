using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.ViewModels.RoleViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public int UserType { get; set; }
        public bool IsSelected { get; set; }
    }
}
