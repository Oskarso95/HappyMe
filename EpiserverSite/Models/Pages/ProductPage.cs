using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "ProductPage", GUID = "aeb436d5-2bc0-4fff-8d44-e1f4331c3f77",
        Description = "Represents a product.")]
    public class ProductPage : SitePageData
    {
        [Display(
            Name = "Product image",
            Description =
                "Main image for product.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ProductImage { get; set; }

        [Display(
            Name = "Product image alt text",
            Description =
                "Alt text for product main image.",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string ProductImageAlt { get; set; }

        [ScaffoldColumn(false)]
        public string ProductName
        {
            get { return this.GetPropertyValue(x => x.PageName); }
            set { this.SetPropertyValue(x => x.ProductName, value); }
        }

        [CultureSpecific]
        [Display(
            Name = "Short description",
            Description =
                "Short product description.",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [UIHint(UIHint.Textarea)]
        public virtual string ShortDescription { get; set; }

        [Display(
            Name = "USPs",
            Description = "Product USPs",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<ProductUSP>))]
        public virtual IList<ProductUSP> USPs { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Long description",
            Description =
                "Long product description.",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        public virtual XhtmlString LongDescription { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Blocks",
            Description =
                "Blocks under long description.",
            GroupName = SystemTabNames.Content,
            Order = 600)]
        public virtual ContentArea Blocks { get; set; }
    }
}