using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Core.Internal;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Pages;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    [TemplateDescriptor(
        Inherited = true,
        Tags = new[] {RenderingTags.Preview, RenderingTags.Edit}, AvailableWithoutTag = false,
        TemplateTypeCategory = TemplateTypeCategories.MvcController)]
    public class PreviewController : ActionControllerBase, IRenderTemplate<BlockData>
    {
        private readonly IContentLoader _contentLoader;
        private readonly DisplayOptions _displayOptions;
        private readonly TemplateResolver _templateResolver;

        public PreviewController(IContentLoader contentLoader, DisplayOptions displayOptions,
            TemplateResolver templateResolver)
        {
            _contentLoader = contentLoader;
            _displayOptions = displayOptions;
            _templateResolver = templateResolver;
        }

        public ActionResult Index(IContent currentContent)
        {
            var startPage = _contentLoader.Get<StartPage>(SiteDefinition.Current.StartPage);
            var viewModel = new PreviewModel(startPage, currentContent);


            var supportedDisplayOptions =
                _displayOptions.Select(x => new {x.Tag, x.Name, Supported = SupportsTag(currentContent, x.Tag)})
                    .ToList();

            if (supportedDisplayOptions.Any(x => x.Supported))
            {
                foreach (var displayOption in supportedDisplayOptions)
                {
                    var contentArea = new ContentArea();

                    contentArea.Items.Add(new ContentAreaItem
                    {
                        ContentLink = currentContent.ContentLink,
                    });

                    var areaModel = new PreviewModel.PreviewArea
                    {
                        ContentArea = contentArea,
                        AreaName = displayOption.Name,
                        AreaTag = displayOption.Tag,
                        Supported = displayOption.Supported,
                    };

                    viewModel.Areas.Add(areaModel);
                }
            }

            return View(viewModel);
        }

        private bool SupportsTag(IContent currentContent, string tag)
        {
            var templateModel = _templateResolver.Resolve(HttpContext, currentContent.GetOriginalType(), currentContent,
                TemplateTypeCategories.MvcPartial, tag);

            return templateModel != null;
        }
    }
}