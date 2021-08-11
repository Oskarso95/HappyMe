using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ProductPage", GUID = "aeb436d5-2bc0-4fff-8d44-e1f4331c3f77", Description = "")]
    public class ProductPage : SitePageData
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