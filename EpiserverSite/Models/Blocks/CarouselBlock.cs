using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "CarouselBlock", GUID = "8fb2de54-da6a-4cc5-bf9a-00f290b21c96", Description = "Carousel with image text and a button")]
    public class CarouselBlock : SiteBlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Carousel item",
            Description = "Items to put in the carousel",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [AllowedTypes(typeof(CarouselItemBlock))]
        public virtual ContentArea CarouselItemsArea { get; set; }

    }
}