using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using EPiServer.Web;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "bd0d56c8-565d-49be-b539-070dbc1da8f2",
        Description = "StartPage of EpiserverSite")]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Background image",
            Description =
                "Large background image displayed on the startpage.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Right content",
            Description =
                "The content area will be shown on the right side of the page.",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [AllowedTypes(typeof(QuickBuyBlock), typeof(TextImageBlock))]
        public virtual ContentArea RightContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Left content",
            Description =
                "The content area will be shown on the right side of the page.",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [AllowedTypes(typeof(QuickBuyBlock), typeof(TextImageBlock))]
        public virtual ContentArea LeftContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Content area",
            Description =
                "The content area will be shown in the middle of the page.",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual ContentArea ContentArea { get; set; }

        //header content
        [CultureSpecific]
        [Display(
            Name = "Site image",
            Description = "Image displayed in header",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference SiteImage { get; set; }

        //footer content

        [CultureSpecific]
        [Display(
            Name = "Footer USPS",
            Description = "USPs in footer",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 200)]
        [AllowedTypes(typeof(ProductPage))]
        public virtual ContentReference FooterUSPs { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Page links",
            Description = "Links to pages shown in footer",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 300)]
        public virtual LinkItemCollection PageLinks { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Page links",
            Description = "Links to pages shown in footer",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 400)]
        public virtual XhtmlString ContactDetails { get; set; }
    }
}