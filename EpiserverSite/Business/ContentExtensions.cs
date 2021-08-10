using EPiServer.Core;
using EPiServer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite.Business
{
    public static class ContentExtensions
    {
        public static IEnumerable<T> FilterForDisplay<T>(this IEnumerable<T> contents, bool visibleInMenu = false)
            where T : IContent
        {
            var accessFilter = new FilterAccess();
            var publishedFilter = new FilterPublished();
            //filter private and non published pages
            contents = contents.Where(x => !publishedFilter.ShouldFilter(x) && !accessFilter.ShouldFilter(x));

            if (visibleInMenu)
            {
                contents = contents.Where(x => VisibleInMenu(x));
            }

            return contents;
        }

        private static bool VisibleInMenu(IContent content)
        {
            if (!(content is PageData page))
            {
                return true;
            }

            return page.VisibleInMenu;
        }
    }
}