using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace EpiserverSite.Models
{
    /*
     Base class for all page types
     */
    public abstract class SitePageData : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Headline",
            Description = "The headline will be shown on the top of the page",
            GroupName = SystemTabNames.PageHeader,
            Order = 100)]
        public virtual String Headline { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Ingress",
            Description = "The ingress will be shown below the headline",
            GroupName = SystemTabNames.PageHeader,
            Order = 200)]
        [UIHint(UIHint.Textarea)]
        public virtual String Ingress { get; set; }


        [CultureSpecific]
        [Display(Name = "Background image",
            Description = "Background image shown on the top of the page",
            GroupName = SystemTabNames.PageHeader,
            Order = 300)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }
    }
}