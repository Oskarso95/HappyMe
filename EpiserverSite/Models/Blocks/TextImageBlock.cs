using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "TextImageBlock", GUID = "f0b7d584-6f2b-4c6f-a2ff-73f6d09eae36",
        Description = "Text or image block to be used on startpage")]
    public class TextImageBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading displayed over image",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image",
            Description = "Image displayed in block",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image alt",
            Description = "Alt text for image",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual string ImageAlt { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Text content displayed in block",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual XhtmlString TextContent { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Background image",
            Description = "Background image of block",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }
    }
}