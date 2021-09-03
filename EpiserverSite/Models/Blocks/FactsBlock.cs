using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EpiserverSite.Business;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "FactsBlock", GUID = "4b7b0e1e-ebe9-4334-8c70-18f5e81edb8e",
        Description = "Information block with two columns/panels")]
    public class FactsBlock : BlockData
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
            Name = "Theme/color",
            Description = "Select background of a set of predefined colors",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [SelectOne(SelectionFactoryType = typeof(ThemeDropDownSelectionFactory))]
        public virtual string Theme { get; set; }

        [ScaffoldColumn(false)]
        public virtual string IconThemeCssClass
        {
            get
            {
                var theme = this.GetPropertyValue(x => x.Theme);
                return theme + "-icon";
            }
            set { this.SetPropertyValue(x => x.IconThemeCssClass, value); }
        }

        [Display(
            Name = "Left column",
            Description = "Left column of block",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual FactsColumnBlock LeftColumn { get; set; }

        [Display(
            Name = "Right column",
            Description = "Right column of block",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual FactsColumnBlock RightColumn { get; set; }
    }
}