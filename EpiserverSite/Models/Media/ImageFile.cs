using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace EpiserverSite.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "ad8edf2b-d7dd-4f5a-8cf1-6097372449fb", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,png,svg")]
    public class ImageFile : ImageData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Alt",
            Description = "Image alt description",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Alt { get; set; }
    }
}