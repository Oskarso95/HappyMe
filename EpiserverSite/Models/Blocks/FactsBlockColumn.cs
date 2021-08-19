using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSite.Business;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "FactsBlockColumn", GUID = "4a792852-df6f-42d7-9d5c-ce7ee9f88174",
        Description = "A column in a factsblock")]
    public class FactsBlockColumn : BlockData
    {
        [IconSelection]
        [Display(
            Name = "Icon",
            Description = "Block icon ",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [Required]
        public virtual string IconCssClass { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of block",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "Descriptive text",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual XhtmlString Description { get; set; }


        [Display(
            Name = "Link block",
            Description = "Link to page or external url",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual LinkBlock LinkBlock { get; set; }
    }
}