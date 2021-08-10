using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Web;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "TeaserBlock", GUID = "ac64938f-240e-4ec9-a7f1-637cca4309e1",
        Description = "Teaser of page or content")]
    public class TeaserBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of teaser",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Ingress",
            Description = "Ingress of teaser",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string Ingress { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Image",
            Description = "Background of teaser",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [UIHint(UIHint.Image)]
        public virtual Url Image { get; set; }
    }
}