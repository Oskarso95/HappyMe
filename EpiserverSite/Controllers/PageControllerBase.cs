using System.Web.Mvc;
using System.Web.Security;
using EPiServer.Web.Mvc;
using System;
using EPiServer.Shell.Security;
using EpiserverSite.Models;
namespace EpiserverSite.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
    {

    }

}