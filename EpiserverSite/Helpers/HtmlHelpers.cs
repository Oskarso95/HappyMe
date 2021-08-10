using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EpiserverSite.Business;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using EPiServer;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace EpiserverSite.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlString MenuList(this HtmlHelper helper, ContentReference rootPage,
            Func<MenuItem, HelperResult> itemTemplate = null, bool includeRoot = false, bool visibleInMenu = true)
        {
            itemTemplate = itemTemplate ?? GetDefaultItemTemplate(helper);
            var currentContentLink = helper.ViewContext.RequestContext.GetContentLink();
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            //IEnumerable<PageData> filter(IEnumerable<PageData> pages) => pages.FilterForDisplay(visibleInMenu);

            var pagePath = contentLoader.GetAncestors(currentContentLink)
                .Reverse()
                .Select(x => x.ContentLink)
                .SkipWhile(x => !x.CompareToIgnoreWorkID(rootPage))
                .ToList();

            var menuItems = contentLoader.GetChildren<PageData>(rootPage)
                .FilterForDisplay(visibleInMenu)
                .Select(x => CreateMenuItems(x, rootPage, pagePath))
                .ToList();


            if (includeRoot)
            {
                menuItems.Insert(0, CreateMenuItems(contentLoader.Get<PageData>(rootPage), rootPage, pagePath));
            }


            var buffer = new StringBuilder();
            var writer = new StringWriter(buffer);

            foreach (var menuItem in menuItems)
            {
                itemTemplate((MenuItem) menuItem).WriteTo(writer);
            }

            return new MvcHtmlString(buffer.ToString());
        }

        private static object CreateMenuItems(PageData page, ContentReference currentContentLink,
            List<ContentReference> pagePath)
        {
            var menuItem = new MenuItem(page)
            {
                Selected = page.ContentLink.CompareToIgnoreWorkID(currentContentLink) ||
                           pagePath.Contains(page.ContentLink)
            };

            return menuItem;
        }

        private static Func<MenuItem, HelperResult> GetDefaultItemTemplate(HtmlHelper helper)
        {
            return x => new HelperResult(writer => writer.Write(helper.PageLink(x.Page)));
        }

        public static IHtmlString Breadcrumbs(this HtmlHelper htmlHelper)
        {
            return null;
        }


        public class MenuItem
        {
            public MenuItem(PageData page)
            {
                Page = page;
            }

            public PageData Page { get; set; }
            public bool Selected { get; set; }
        }
    }
}