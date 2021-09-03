using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ContactPage", GUID = "682e1d7e-e452-4eb0-8d57-733394cf456c", Description = "")]
    public class ContactPage : SitePageData
    {
        [Display(
            Name = "Left contact block",
            Description = "Contact block displayed on the left side.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual ContactPageBlock LeftBlock { get; set; }

        [Display(
            Name = "Center contact block",
            Description = "Contact block displayed in the middle.",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual ContactPageBlock MiddleBlock { get; set; }

        [Display(
            Name = "right contact block",
            Description = "Contact block displayed on the right side.",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual ContactPageBlock RightBlock { get; set; }
    }
}