using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ArticlePage", GUID = "42c557e2-d12a-4ddf-acf6-09ac5938d94a",
        Description = "Article page")]
    public class ArticlePage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading shown on top of the page",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Ingress",
            Description =
                "The ingress is displayed below the header on top of the page",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [UIHint(UIHint.Textarea)]
        public virtual string Ingress { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Background image",
            Description =
                "Image to set background of page",
            GroupName = SystemTabNames.Content,
            Order = 250)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Main Content",
            Description =
                "The content is displayed below the heading and ingress",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual XhtmlString MainContent { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Aside area",
            Description =
                "The content is displayed on the right side of the page.",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual ContentArea AsideArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Bottom area",
            Description =
                "The content is displayed on the bottom of the page.",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        public virtual ContentArea BottomArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Icon",
            Description =
                "Icon displayed in the footer",
            GroupName = SystemTabNames.Content,
            Order = 600)]
        public virtual ContentArea Icon { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Icon image",
            Description =
                "Icon image displayed primary in the footer links",
            GroupName = SystemTabNames.Content,
            Order = 700)]
        public virtual ContentArea IconImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Hide from search results",
            Description =
                "Icon image displayed primary in the footer links",
            GroupName = SystemTabNames.Content,
            Order = 800)]
        public virtual bool HideFromSearch { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Hide from article listings",
            Description =
                "Icon image displayed primary in the footer links",
            GroupName = SystemTabNames.Content,
            Order = 1000)]
        public virtual bool HideFromListings { get; set; }
    }
}