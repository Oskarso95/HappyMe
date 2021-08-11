using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "FAQ", GUID = "973bb10b-232c-45d8-b1f8-7ac314198ed4", Description = "")]
    public class FAQPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description =
                "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }
    }
}