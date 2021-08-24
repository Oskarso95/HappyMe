using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EpiserverSite.Business;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "ListingSwipeBlock", GUID = "04c1ebea-049d-49e6-a904-06953688daf6",
        Description = "Renders the content in small cards")]
    public class ListingSwipeBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading in block",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Theme color",
            Description = "Sets background/theme of block",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [SelectOne(SelectionFactoryType = typeof(ThemeDropDownSelectionFactory))]
        public virtual string CssClass { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Content",
            Description = "Drag and drop article/product pages to display",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [AllowedTypes(typeof(ArticlePage), typeof(ProductPage))]
        public virtual ContentArea MainContent { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Link",
            Description = "Optional link",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual Url Link { get; set; }
    }
}