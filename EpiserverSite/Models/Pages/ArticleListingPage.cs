using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EpiserverSite.Business;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ArticleListingPage", GUID = "adfca316-2f77-4283-8b14-58c4d2810f0f",
        Description = "Article listing page")]
    public class ArticleListingPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main content area",
            Description = "Content area to display Article page or listing block",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [AllowedTypes(typeof(ArticlePage), typeof(ListingSwipeBlock))]
        public virtual ContentArea MainContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Article list sort order",
            Description = "Decides sort order of articles",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [SelectOne(SelectionFactoryType = typeof(ArticleDropdownSelectionFactory))]
        public virtual string ArticleSortOrder { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Bottom content area",
            Description = "Content area below main content",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [AllowedTypes(typeof(ArticlePage), typeof(ListingSwipeBlock))]
        public virtual ContentArea BottomContentArea { get; set; }
    }
}