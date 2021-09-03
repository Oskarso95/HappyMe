using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverSite.Models.Pages
{
    [ContentType(DisplayName = "FAQListingPage", GUID = "bd204bc8-1a31-44e7-b798-0a2cd275a12d", Description = "")]
    [AvailableContentTypes(Include = new[] {typeof(FAQPage)})]
    public class FAQListingPage : SitePageData
    {
    }
}