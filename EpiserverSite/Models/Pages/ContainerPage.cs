using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSite.Business.Rendering;

namespace EpiserverSite.Models.Pages
{
    [ContentType(GUID = "b5d201a2-cce9-4f04-b6fe-e5f8bf845432", GroupName = Global.GroupNames.Specialized)]
    public class ContainerPage : SitePageData, IContainerPage
    {
    }
}