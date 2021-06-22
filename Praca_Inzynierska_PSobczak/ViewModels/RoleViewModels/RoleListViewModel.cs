using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.ViewModels.RoleViewModels
{
    public class RoleListViewModel
    {
        public IEnumerable<RoleListItemViewModel> Roles { get; set; }
    }
}
