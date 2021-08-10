using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer.Web.Routing;
using EpiserverSite.Models;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Business
{
    public class PageContextActionFilter : IResultFilter
    {
        private readonly PageViewContextFactory _pageViewContextFactory;

        public PageContextActionFilter(PageViewContextFactory pageViewContextFactory)
        {
            _pageViewContextFactory = pageViewContextFactory;
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;

            if (viewModel is IPageViewModel<SitePageData> model)
            {
                var currentContentLink = filterContext.RequestContext.GetContentLink();

                var layoutModel = model.Layout ??
                                  _pageViewContextFactory.CreateLayoutModel(currentContentLink,
                                      filterContext.RequestContext);

                model.Layout = layoutModel;
            }
        }


        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}
