using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
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

        public static IHtmlContent ActionLinkNonEncoded(this HtmlHelper htmlHelper, string linkText,
                        string action, string controller, object routeValues, object htmlAttributes)
        {
            TagBuilder tagBuilder;
           
            tagBuilder = new TagBuilder("a");

            tagBuilder.InnerHtml.Append(linkText);

           

            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return tagBuilder;
        }
        public static IHtmlContent IconActionLink(this IHtmlHelper helper, string iconName, object iconHtmlAttributes, string linkText, string actionName, string controllerName, object routeValues, object linkHtmlAttributes)
        {
            var content = new HtmlContentBuilder();
            var linkStart = new TagBuilder("a");
            
            string rVString = "?";
            foreach(var r in new RouteValueDictionary(routeValues))
            {
                rVString += r.Key.ToString()+"="+r.Value.ToString()+"&";
            }
            rVString.Remove(rVString.Length-1);
            linkStart.MergeAttribute("href", "../"+controllerName+"/"+actionName+"/"+rVString);
            linkStart.MergeAttributes(new RouteValueDictionary(linkHtmlAttributes));
            linkStart.InnerHtml.Append(linkText);
            linkStart.TagRenderMode = TagRenderMode.StartTag;

            var icon = MaterialIcon(helper, iconName, iconHtmlAttributes);

            var linkEnd = new TagBuilder("a") { TagRenderMode = TagRenderMode.EndTag };

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
