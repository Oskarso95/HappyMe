using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.UI.Report;
using EPiServer.Web.Routing;
using EpiserverSite.Business;
using EpiserverSite.Models.Pages;

namespace EpiserverSite.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public T CurrentPage { get; set; }

        public LayoutModel Layout { get; set; }
        public List<NavItemViewModel> Breadcrumbs { get; set; }

        public List<NavItemViewModel> NavItems { get; set; }


        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
            Breadcrumbs = GetBreadcrumbs(currentPage.ContentLink);
            NavItems = GetNavigationItems(currentPage.ContentLink, 4);
        }

        private static List<NavItemViewModel> GetBreadcrumbs(ContentReference currentPage)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var pageData = contentLoader.Get<SitePageData>(currentPage);
            var pages = contentLoader.GetAncestors(currentPage).Reverse().Cast<PageData>()
                .SkipWhile(x => x.ContentLink.CompareToIgnoreWorkID(ContentReference.RootPage)).FilterForDisplay();
            pages = pages.Append(pageData);

            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();

            return pages.Select(parent =>
                new NavItemViewModel()
                {
                    Name = parent.PageName,
                    Active = parent.ContentLink.CompareToIgnoreWorkID(currentPage),
                    Link = urlResolver.GetUrl(parent.LinkURL),
                }).ToList();
        }

        private static List<NavItemViewModel> GetNavigationItems(ContentReference currentPage, int numLevels,
            bool includeRoot = false)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var startPage = contentLoader.Get<PageData>(ContentReference.StartPage);
            var urlResolver = UrlResolver.Current;
            var navbarItems = new List<NavItemViewModel>();
            var topLevelPages = contentLoader.GetChildren<PageData>(ContentReference.StartPage)
                .FilterForDisplay(true);

            foreach (var page in topLevelPages)
            {
                navbarItems.Add(new NavItemViewModel
                {
                    Name = page.PageName,
                    Link = urlResolver.GetUrl(page.LinkURL),
                    Active = page.ContentLink.CompareToIgnoreWorkID(currentPage),
                    Children = AddMenuItems(page, contentLoader, currentPage, 0, numLevels)
                });
            }

            if (includeRoot)
            {
                return navbarItems.Prepend(new NavItemViewModel
                {
                    Active = startPage.ContentLink.CompareToIgnoreWorkID(currentPage),
                    Name = startPage.PageName,
                    Link = urlResolver.GetUrl(startPage.LinkURL),
                    Children = new List<NavItemViewModel>(),
                }).ToList();
            }

            return navbarItems;
        }


        private static List<NavItemViewModel> AddMenuItems(PageData page, IContentLoader contentLoader,
            ContentReference currentPage,
            int level, int numLevels)
        {
            var pageList = new List<NavItemViewModel>();

            var children = contentLoader.GetChildren<PageData>(page.ContentLink).FilterForDisplay(true);

            if (children.Any() && level < numLevels)
            {
                foreach (var child in children)
                {
                    pageList.Add(new NavItemViewModel
                    {
                        Name = child.PageName,
                        Link = UrlResolver.Current.GetUrl(child.LinkURL),
                        Active = page.ContentLink.CompareToIgnoreWorkID(currentPage),
                        Children = AddMenuItems(child, contentLoader, currentPage, level + 1, numLevels),
                    });
                }

                return pageList;
            }

            return new List<NavItemViewModel>();
        }

        public static PageViewModel<T> Create<T>(T model) where T : SitePageData
        {
            return new PageViewModel<T>(model);
        }
    }
}