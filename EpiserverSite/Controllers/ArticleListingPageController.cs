using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.PageExtensions;
using EpiserverSite.Business;
using EpiserverSite.Business.Rendering;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;
using ImageProcessor.Imaging.Colors;

namespace EpiserverSite.Controllers
{
    public class ArticleListingPageController : PageControllerBase<ArticleListingPage>
    {
        private readonly IContentLoader _contentLoader;

        public ArticleListingPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public ActionResult Index(ArticleListingPage currentPage)
        {
            var articlePages = GetArticlePages(currentPage);
            var articlesInMainContentArea = GetContentAreaArticles(currentPage);
            var articleListings = FilterArticlePages(articlePages, articlesInMainContentArea);
            var sortOrder = currentPage.ArticleSortOrder;

            var model = new ArticleListingPageViewModel(currentPage)
            {
                MainContentArea = addItemsInContentArea(articlesInMainContentArea),
                ArticleListings = addItemsInContentArea(articleListings),
                BottomContentArea = currentPage.BottomContentArea
            };


            return View(model);
        }

        private IEnumerable<ArticlePage> GetArticlePages(ArticleListingPage currentPage)
        {
            return _contentLoader.GetChildren<ArticlePage>(currentPage.ContentLink)
                .Where(x => !x.GetPropertyValue<bool>("HideFromListings")).FilterForDisplay();
        }

        private IEnumerable<ArticlePage> GetContentAreaArticles(ArticleListingPage currentPage)
        {
            if (currentPage.MainContentarea != null)
            {
                return currentPage.MainContentarea.Items
                    .Select(x => _contentLoader.Get<ArticlePage>(x.ContentLink));
            }

            return new List<ArticlePage>();
        }

        private IEnumerable<ArticlePage> FilterArticlePages(IEnumerable<ArticlePage> articlePages,
            IEnumerable<ArticlePage> contentAreaArticles)
        {
            return articlePages.Where(y =>
                !contentAreaArticles.Any(x => x.ContentLink.CompareToIgnoreWorkID(y.ContentLink)));
        }

        private ContentArea addItemsInContentArea(IEnumerable<ArticlePage> articlePages)
        {
            var articleListingsContentArea = new ContentArea();

            foreach (var articlePage in articlePages)
            {
                var cai = new ContentAreaItem
                {
                    ContentLink = articlePage.ContentLink,
                };
                articleListingsContentArea.Items
                    .Add(cai); // <-- throws error here complaining about object ref not set.
            }

            return articleListingsContentArea;
        }
    }
}