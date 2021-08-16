using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace EpiserverSite.Models.Media
{
    [ContentType(GUID = "ad8edf2b-d7dd-4f5a-8cf1-6097372449fb")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,png,svg")]
    public class ImageFile : ImageData
    {
        public virtual string Copyright { get; set; }

        public virtual string Alt { get; set; }
    }
}