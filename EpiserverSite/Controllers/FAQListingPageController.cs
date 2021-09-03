using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.ServiceLocation;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class FAQListingPageController : PageControllerBase<FAQListingPage>
    {
        private readonly IContentLoader _contentLoader;

        public FAQListingPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public ActionResult Index(FAQListingPage currentPage)
        {
            var FAQChildren = _contentLoader.GetChildren<FAQPage>(currentPage.ContentLink);
            var model = new FAQListingPageViewModel(currentPage);

            if (FAQChildren.Any())
            {
                model.FAQPages = FAQChildren;
            }
            else
            {
                model.FAQPages = new List<FAQPage>();
            }

            return View(model);
        }
    }
}