using System.Web.Mvc;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class ArticleListingPageController : PageControllerBase<ArticleListingPage>
    {
        public ActionResult Index(ArticleListingPage currentPage)
        {
            var model = new ArticleListingPageViewModel
            {
                ArticleListings = null,
                MainContentArea = currentPage.MainContentarea,
                BottomContentArea = currentPage.BottomContentArea,
            };

            return View(model);
        }
    }
}