using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.SessionState;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc.Html;

namespace EpiserverSite.Business.Rendering
{
    public class CustomContentAreaRenderer : ContentAreaRenderer
    {
        protected override string GetContentAreaItemCssClass(HtmlHelper helper, ContentAreaItem contentAreaItem)
        {
            var tag = GetContentAreaItemTemplateTag(helper, contentAreaItem);

            return String.Format("Block {0} {1} {2}", GetTypeSpecificCssClasses(contentAreaItem, ContentRepository),
                GetCssClassForTag(tag), tag);
        }

        public static string GetCssClassForTag(string tag)
        {
            return tag.ToLower() switch
            {
                "row w-100" => "full",
                "row w-66" => "twothirds",
                "row w-50" => "half",
                "row w-33" => "onethird",
                "row w-25" => "onefourth",
                _ => "",
            };
        }


        public static string GetTypeSpecificCssClasses(ContentAreaItem contentAreaItem,
            IContentRepository contentRepository)
        {
            var content = contentAreaItem.GetContent();
            var cssClass = content == null ? string.Empty : content.GetOriginalType().Name.ToLowerInvariant();


            if (content is ICustomCssInContentArea customClassContent &&
                !string.IsNullOrWhiteSpace(customClassContent.ContentAreaCssClass))
            {
                cssClass += $" {customClassContent.ContentAreaCssClass}";
            }

            return cssClass;
        }
    }
}