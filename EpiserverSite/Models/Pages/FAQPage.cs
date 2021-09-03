using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EpiserverSite.Business;
using EpiserverSite.Business.Rendering;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "FAQ", GUID = "973bb10b-232c-45d8-b1f8-7ac314198ed4",
        GroupName = Global.GroupNames.Specialized)]
    public class FAQPage : ContainerPageBase, IContainerPage
    {
        [Display(
            Name = "Icon",
            Description =
                "Icon of page",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [IconSelection]
        public virtual string IconCssClass { get; set; }

        [Display(
            Name = "Icon theme",
            Description =
                "Theme/color of icon",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [SelectOne(SelectionFactoryType = typeof(ThemeDropDownSelectionFactory))]
        public virtual string ThemeCssClass { get; set; }

        [ScaffoldColumn(false)]
        public virtual string IconThemeCssClass
        {
            get
            {
                var themeCssClass = this.GetPropertyValue(x => x.ThemeCssClass);
                var iconThemeCssClass = themeCssClass + "-icon";
                return iconThemeCssClass;
            }
            set { this.SetPropertyValue(x => x.IconThemeCssClass, value); }
        }


        [ScaffoldColumn(false)]
        public virtual string Question
        {
            get { return this.GetPropertyValue(x => x.PageName); }
            set { this.SetPropertyValue(x => x.Question, value); }
        }

        [Display(
            Name = "Text content",
            Description =
                "Text content displayed below Question",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual XhtmlString TextContent { get; set; }
    }
}