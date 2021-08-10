using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EpiserverSite.Business.Rendering
{
    class SiteViewEngine : RazorViewEngine
    {
        public static readonly string[] AdditionalPartialViewFormats = new[]
        {
            TemplateCoordinator.BlockFolder + "{0}.cshtml",
            TemplateCoordinator.PagePartialsFolder + "{0}.cshtml"
        };

        public SiteViewEngine()
        {
            PartialViewLocationFormats = PartialViewLocationFormats.Union(AdditionalPartialViewFormats).ToArray();
        }
    }
}