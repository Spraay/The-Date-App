using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace App.TheDate.Extensions
{
    public static class HtmlHelpersExtensions 
    {
        public static IHtmlContent IconActionLink(this IHtmlHelper helper,
            string iconName,
            object iconHtmlAttributes,
            string linkText,
            string actionName,
            string controllerName,
            object routeValues,
            object linkHtmlAttributes)
        {
            //UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var content = new HtmlContentBuilder();
            var anchorStart = new TagBuilder("a");
            
            string routeValuesToString = "?";
            foreach(var r in new RouteValueDictionary(routeValues))
            {
                routeValuesToString += r.Key.ToString()+"="+r.Value.ToString()+"&";
            }
            routeValuesToString.Remove(routeValuesToString.Length-1);

            anchorStart.MergeAttribute("href", "../"+controllerName+"/"+actionName+"/"
                + routeValuesToString);

            anchorStart.MergeAttributes(new RouteValueDictionary(linkHtmlAttributes));
            anchorStart.InnerHtml.Append(linkText);
            anchorStart.TagRenderMode = TagRenderMode.StartTag;

            var icon = MaterialIcon(helper, iconName, iconHtmlAttributes);

            var anchorEnd = new TagBuilder("a") { TagRenderMode = TagRenderMode.EndTag };

            content.AppendHtml(anchorStart);
            content.AppendHtml(icon);
            content.AppendHtml(anchorEnd);

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
