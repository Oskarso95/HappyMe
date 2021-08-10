using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

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
            Name = "Opening hours",
            Description = "Displays opening hours in the footer",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 100)]
        public virtual XhtmlString OpeningHours { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Address",
            Description = "The address will be shown in the footer",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 200)]
        public virtual XhtmlString Address { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Pagelinks",
            Description = "Links to pages shown in footer",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 300)]
        public virtual LinkItemCollection PageLinks { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Site title",
            Description = "Title displayed in navbar",
            GroupName = Global.GroupNames.SiteSettings,
            Order = 400)]
        public virtual string SiteTitle { get; set; }
    }
}