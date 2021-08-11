using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Views.Shared.Blocks
{
    [ContentType(DisplayName = "QuickBuyBlock", GUID = "270e3342-0ded-4dce-80ca-3914dd668c57",
        Description = "Block to trigger sales for product")]
    public class QuickBuyBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Product",
            Description = "Link to product page",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [AllowedTypes(typeof(ProductPage))]
        [Required]
        public virtual ContentReference Product { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Button text",
            Description = "Fallback text for button",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string ButtonText { get; set; }
    }
}