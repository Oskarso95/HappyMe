using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "bd0d56c8-565d-49be-b539-070dbc1da8f2",
        Description = "StartPage of EpiserverSite")]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main content",
            Description =
                "The main content area will be shown in the middle of the page.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual ContentArea MainContentArea { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Page links",
            Description = "Links to pages shown in footer",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 300)]
        public virtual LinkItemCollection PageLinks { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Site image",
            Description = "Image displayed in header",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 400)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference SiteImage { get; set; }
    }
}