using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "QuoteBlock", GUID = "170cac93-4fd0-484b-b622-ae31ada53d43",
        Description = "Displays quote")]
    public class QuoteBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Quote text",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [Required]
        public virtual XhtmlString Text { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image",
            Description = "Image of quote block",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Background image",
            Description = "Background-image of quote block",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Author",
            Description = "Authors name",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual string Author { get; set; }
    }
}