using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.DataAnnotations;

namespace EpiserverSite
{
    public class Global
    {
        public static class ContentAreaTags
        {
            public const string FullWidth = "col-12";
            public const string HalfWidth = "col-6";
            public const string TwoThirdsWidth = "col-8";
            public const string OneThirdWidth = "col-4";
            public const string OneFourthWidth = "col-3";
        }

        public static class ContentAreaWidths
        {
            public const int FullWidth = 12;
            public const int HalfWidth = 6;
            public const int TwoThirds = 8;
            public const int OneThirdWidth = 4;
            public const int OneFourthWidth = 3;
        }

        [GroupDefinitions()]
        public static class GroupNames
        {
            [Display(Name = "Site Settings", Order = 20)]
            public const string SiteSettings = "Sitesettings";
        }
    }
}