using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace EpiserverSite.Models.ViewModels
{
    public class LayoutModel
    {
        [UIHint(UIHint.Image)] public ContentReference SiteImage { get; set; }

        public LinkItemCollection PageLinks { get; set; }

        public LinkItemCollection FooterIconLinks { get; set; }

        public XhtmlString ContactDetails { get; set; }

        public ContentReference FooterUSPs { get; set; }
    }
}