using System;
using System.Collections.Generic;
using EPiServer.Core;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class ArticleListingPageViewModel : PageViewModel<ArticleListingPage>
    {
        public ArticleListingPageViewModel(ArticleListingPage currentPage) : base(currentPage)
        {
        }

        public ContentArea MainContentArea { get; set; }

        public IEnumerable<ArticlePage> ArticleListings { get; set; }

        public ContentArea BottomContentArea { get; set; }
    }
}