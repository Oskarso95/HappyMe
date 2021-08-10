using System.Collections;
using System.Collections.Generic;

namespace EpiserverSite.Models.ViewModels
{
    public class NavItemViewModel
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public bool Active { get; set; }

        public IList<NavItemViewModel> Children { get; set; }
    }
}