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
            public const string FullWidth = "row w-100";
            public const string TwoThirdsWidth = "row w-66";
            public const string HalfWidth = "row w-50";
            public const string OneThirdWidth = "row w-33";
            public const string OneFourthWidth = "row w-25";
            public const string Vertical = "Vertical row";
            public const string Horizontal = "Horizontal row";
        }


        [GroupDefinitions()]
        public static class GroupNames
        {
            [Display(Name = "Site Settings", Order = 20)]
            public const string SiteSettings = "Sitesettings";
        }
    }
}