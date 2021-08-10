using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite.Models.ViewModels
{
    public class LayoutModel
    {
        public string SiteTitle { get; set; }
        public XhtmlString OpeningHours { get; set; }

        public XhtmlString Address { get; set; }

        public LinkItemCollection PageLinks { get; set; }
    }
}