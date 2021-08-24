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
            public const string FullWidth = "w-100";
            public const string TwoThirdsWidth = "w-66";
            public const string HalfWidth = "w-50";
            public const string OneThirdWidth = "w-33";
            public const string OneFourthWidth = "w-25";
            public const string Vertical = "vertical";
            public const string Horizontal = "horizontal";
        }


        [GroupDefinitions()]
        public static class GroupNames
        {
            [Display(Name = "Site Settings", Order = 20)]
            public const string SiteSettings = "Sitesettings";
        }
    }
}