using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "LinkBlock", GUID = "433462e2-941d-4759-a0ff-357a57986a4f", Description = "")]
    public class LinkBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Link",
            Description = "Page or external link",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual Url Link { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Link text",
            Description = "Link text",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string LinkText { get; set; }
    }
}