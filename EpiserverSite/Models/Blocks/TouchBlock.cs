using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "TouchBlock", GUID = "dc3587fd-7f88-49ee-8b9a-ba4afb01647b", Description = "")]
    public class TouchBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Name { get; set; }
    }
}