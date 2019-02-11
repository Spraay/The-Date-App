using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace App.TheDate.Extensions
{
    public static class HtmlHelpersExtensions 
    {
        public static IHtmlContent IconActionLink(this IHtmlHelper helper, string iconName, object iconHtmlAttributes, string linkText, string actionName, string controllerName, object routeValues, object linkHtmlAttributes)
        {
            var content = new HtmlContentBuilder();
            var linkStart = new TagBuilder("a");
                linkStart.MergeAttributes(new RouteValueDictionary(routeValues));
                linkStart.MergeAttributes(new RouteValueDictionary(linkHtmlAttributes));
                linkStart.TagRenderMode = TagRenderMode.StartTag;
            var icon = MaterialIcon(helper, iconName, iconHtmlAttributes);
            var linkEnd = new TagBuilder("a")
            {
                TagRenderMode = TagRenderMode.EndTag
            };
            content.AppendHtml(linkStart);
            content.AppendHtml(icon);
            content.AppendHtml(linkEnd);
            return content;
        }

        public static IHtmlContent MaterialIcon(this IHtmlHelper helper, string iconName)
        {
            return MaterialIcon(helper, iconName, null);
        }

        public static IHtmlContent MaterialIcon(this IHtmlHelper helper, string iconName, object htmlAttributes)
        {
            var icon = new TagBuilder("i");
            if(htmlAttributes!=null)
                icon.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            icon.AddCssClass("material-icons");
            icon.InnerHtml.Append(iconName);
            icon.TagRenderMode= TagRenderMode.Normal;
            return icon;
        }
    }
}
