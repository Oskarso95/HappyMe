using System;
using EPiServer.Core;

namespace EpiserverSite.Models.ViewModels
{
    public class ArticleListingPageViewModel
    {
        public ContentArea MainContentArea { get; set; }

        public ContentArea ArticleListings { get; set; }

        public ContentArea BottomContentArea { get; set; }
    }
}