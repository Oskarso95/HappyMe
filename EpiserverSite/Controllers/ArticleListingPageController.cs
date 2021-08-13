﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
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
            var articlesInContentArea = GetContentAreaArticles(currentPage);
            var filteredArticlePages = FilterArticlePages(articlePages, articlesInContentArea);
            var sortOrder = currentPage.ArticleSortOrder;

            var model = new ArticleListingPageViewModel(currentPage)
            {
                ArticleListings = filteredArticlePages,
                MainContentAreaArticles = articlesInContentArea,
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
    }
}