using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using EpiserverSite.Business;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "InformationBlock", GUID = "1e5d0427-e88c-484a-a435-b61b4b0e1c74", Description = "")]
    public class InformationBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of block",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Text",
            Description = "Textcontent of block",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [UIHint(UIHint.Textarea)]
        public virtual string TextContent { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Theme",
            Description = "Sets theme color of the block",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [SelectOne(SelectionFactoryType = typeof(ThemeDropDownSelectionFactory))]
        public virtual string CssClass { get; set; }
    }
}