using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.PageExtensions;
using EpiserverSite.Business;
using EpiserverSite.Business.Rendering;
using EpiserverSite.Models.Blocks;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;
using ImageProcessor.Imaging.Colors;
using static EpiserverSite.Helpers.ContentAreaHelpers;

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
                MainContentArea = currentPage.MainContentArea,
                ArticleListings = FilterArticlePages(articlePages, articlesInMainContentArea),
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
            if (currentPage.MainContentArea != null)
            {
                return currentPage.MainContentArea.GetFilteredItemsOfType<ArticlePage>().ToList();
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
                    .Add(cai);
            }

            return articleListingsContentArea;
        }
    }
}