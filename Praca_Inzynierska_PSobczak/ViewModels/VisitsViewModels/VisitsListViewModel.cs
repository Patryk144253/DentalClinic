using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.ViewModels.VisitsViewModels
{
    public class VisitsListViewModel
    {
        public IEnumerable<VisitsListItemViewModel> Visits { get; set; }
    }
}
