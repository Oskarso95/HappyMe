using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace EpiserverSite.Helpers
{
    public static class ContentAreaHelpers
    {
        public static bool IsNullOrEmpty(this ContentArea contentArea)
        {
            return contentArea == null || !contentArea.FilteredItems.Any();
        }

        public static List<T> GetFilteredItemsOfType<T>(this ContentArea contentArea) where T : IContentData
        {
            var items = new List<T>();

            if (contentArea.IsNullOrEmpty())
            {
                return items;
            }

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            foreach (var cai in contentArea.FilteredItems)
            {
                IContentData item;
                if (!contentLoader.TryGet(cai.ContentLink, out item))
                {
                    continue;
                }

                if (item is T)
                {
                    items.Add((T) item);
                }
            }

            return items;
        }
    }
}