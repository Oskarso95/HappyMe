using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EpiserverSite.Controllers;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Business.Rendering
{
    class TemplateCoordinator : IViewTemplateModelRegistrator
    {
        public const string BlockFolder = "~/Views/Shared/Blocks/";
        public const string PagePartialsFolder = "~/Views/Shared/PagePartials/";

        public static void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
            //Disable DefaultPageController for page types that shouldn't have any renderer as pages
            //if (args.ItemToRender is IContainerPage && args.SelectedTemplate != null &&
            //    args.SelectedTemplate.TemplateType == typeof(DefaultPageController))
            //{
            //    args.SelectedTemplate = null;
            //}
        }


        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(ArticlePage), new TemplateModel
            {
                Name = "ArticlePageVertical",
                Tags = new[] {Global.ContentAreaTags.Vertical},
                AvailableWithoutTag = false,
                Path = PagePartialPath("ArticlePageVertical.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ArticlePage), new TemplateModel
            {
                Name = "ArticlePageHorizontal",
                Tags = new[] {Global.ContentAreaTags.Horizontal},
                AvailableWithoutTag = false,
                Path = PagePartialPath("ArticlePageHorizontal.cshtml")
            });
        }

        private static string BlockPath(string fileName)
        {
            return string.Format("{0}{1}", BlockFolder, fileName);
        }

        private static string PagePartialPath(string fileName)
        {
            return string.Format("{0}{1}", PagePartialsFolder, fileName);
        }
    }
}