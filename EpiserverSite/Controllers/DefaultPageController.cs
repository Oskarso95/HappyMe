using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EpiserverSite.Models;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : PageControllerBase<SitePageData>
    {

        public ViewResult Index(SitePageData currentPage)
        {
            var model = CreateModel(currentPage);
            return View($"~/Views/{currentPage.GetOriginalType().Name}/Index.cshtml", model);
        }

        public static IPageViewModel<SitePageData> CreateModel(SitePageData currentPage)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(currentPage.GetOriginalType());
            return Activator.CreateInstance(type, currentPage) as IPageViewModel<SitePageData>;

        }
    }
}