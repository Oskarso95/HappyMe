using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EpiserverSite.Business;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "ContactPageBlock", GUID = "307b090b-a361-4b15-bf21-357380df78dc", Description = "")]
    public class ContactPageBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Icon",
            Description = "Icon of block",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [IconSelection]
        public virtual string IconCssClass { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Icon theme",
            Description = "Sets theme/color of icon",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [SelectOne(SelectionFactoryType = typeof(ThemeDropDownSelectionFactory))]
        public virtual string ThemeCssClass { get; set; }

        [ScaffoldColumn(false)]
        public virtual string IconThemeCssClass
        {
            get
            {
                var theme = this.GetPropertyValue(x => x.ThemeCssClass);
                return theme + "-icon";
            }
            set { this.SetPropertyValue(x => x.IconThemeCssClass, value); }
        }

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Block heading",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Block content",
            Description = "Content in block",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual XhtmlString Content { get; set; }
    }
}