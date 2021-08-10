using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Web;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "CarouselItemBlock", GUID = "75afb827-5a2e-4483-aebc-c4c4c6b01fea",
        Description = "Item to put in carousel")]
    public class CarouselItemBlock : SiteBlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Headline",
            Description = "Headline in item",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Headline { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Image",
            Description = "Image in item",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [UIHint(UIHint.Image)]
        public virtual Url Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Text content",
            Description = "Text in item",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual string TextContent { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Button text",
            Description = "Text displayed on button",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual string ButtonText { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Button link",
            Description = "Link that button points to",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        public virtual Url ButtonLink { get; set; }
    }
}