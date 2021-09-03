using System.Collections.Generic;
using EpiserverSite.Models;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class FAQListingPageViewModel : PageViewModel<FAQListingPage>
    {
        public FAQListingPageViewModel(FAQListingPage currentPage) : base(currentPage)
        {
        }

        public IEnumerable<FAQPage> FAQPages { get; set; }
    }
}