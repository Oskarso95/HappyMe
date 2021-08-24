using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing;

namespace EpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "CustomerStoriesBlock", GUID = "db34c54e-61d6-431b-8d46-bce050038f2e",
        Description = "Displays customer stories in a block")]
    public class CustomerStoriesListingBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Customer stories",
            Description = "List of customer stories to display.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<CustomerStory>))]
        public virtual IList<CustomerStory> CustomerStories { get; set; }
    }
}