#pragma checksum "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2c2c344d9b85cdb7e324e6fb4dee68936d33c2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Friendships_UserFriends), @"mvc.1.0.view", @"/Views/Friendships/UserFriends.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Friendships/UserFriends.cshtml", typeof(AspNetCore.Views_Friendships_UserFriends))]
namespace AspNetCore
{
    #line hidden
#line 2 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 3 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\_ViewImports.cshtml"
using DatingApplicationV2.Areas.Identity;

#line default
#line hidden
#line 4 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\_ViewImports.cshtml"
using App.Model.View;

#line default
#line hidden
#line 5 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\_ViewImports.cshtml"
using App.Model.Entities;

#line default
#line hidden
#line 6 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\_ViewImports.cshtml"
using App.Service.Abstract;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2c2c344d9b85cdb7e324e6fb4dee68936d33c2e", @"/Views/Friendships/UserFriends.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"805b65725f9c98ebfddbadd6b3513a917bb782fa", @"/Views/_ViewImports.cshtml")]
    public class Views_Friendships_UserFriends : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Explore", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-large rounded red tooltipped"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-position", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-tooltip", new global::Microsoft.AspNetCore.Html.HtmlString("Delete Friend"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Friendships", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-large rounded blue tooltipped"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-tooltip", new global::Microsoft.AspNetCore.Html.HtmlString("Show Details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-large rounded green tooltipped"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-tooltip", new global::Microsoft.AspNetCore.Html.HtmlString("Mark as met"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Meet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Meet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
  
    ViewData["Title"] = "User Friends";
    var usersMarkedAsMet = (IEnumerable<Guid>) ViewBag.MarkedAsMet;
    var usersMet = (IEnumerable<Guid>)ViewBag.UsersMet;

#line default
#line hidden
            BeginContext(202, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
 if (Model.Any())
{

#line default
#line hidden
            BeginContext(226, 319, true);
            WriteLiteral(@"    <div class=""grey darken-3 z-depth-3"" style=""padding: 1vw; margin-top: -10px;"">
        <div class=""center"">
            <p class=""white-text"" style=""font-size: 3vw;"">Friends<i style=""vertical-align: bottom; font-size: 4vw !important;"" class=""inline-icon material-icons"">group</i></p>
        </div>
    </div>
");
            EndContext();
#line 16 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(557, 319, true);
            WriteLiteral(@"    <div class=""valign-wrapper my-wrapper row"">
        <div class=""col s12"">
            <div class=""col s12 center""><i class=""material-icons orange-text"" style=""font-size: 150px;"">sentiment_dissatisfied</i></div>
            <h1 class=""orange-text center""> Your friend list seems to be empty. Try add some friends ");
            EndContext();
            BeginContext(876, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea6ee4aebb44f12990f067b50d920be", async() => {
                BeginContext(923, 4, true);
                WriteLiteral("here");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(931, 35, true);
            WriteLiteral("</h1>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 25 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
}

#line default
#line hidden
            BeginContext(969, 50, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 29 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1068, 147, true);
            WriteLiteral("            <div class=\"col m4\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-image inline\">\r\n                        ");
            EndContext();
            BeginContext(1215, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "aa5090670f2643c7b5985c103895bfc7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1225, "~/images/userimages/", 1225, 20, true);
#line 34 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
AddHtmlAttributeValue("", 1245, Html.DisplayFor(m => item.ProfileImageSrc), 1245, 43, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1290, 133, true);
            WriteLiteral("\r\n                        <span class=\"card-title\" style=\"width:100%; background: rgba(0, 0, 0, 0.5);\">\r\n                            ");
            EndContext();
            BeginContext(1424, 36, false);
#line 36 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                       Write(Html.DisplayFor(m => item.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1460, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(1463, 35, false);
#line 36 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                                              Write(Html.DisplayFor(m => item.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1498, 189, true);
            WriteLiteral("\r\n                        </span>\r\n                    </div>\r\n                    <div class=\"card-action grey\">\r\n                        <div class=\"center\">\r\n                            ");
            EndContext();
            BeginContext(1687, 346, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7af5bec1b88441a292fda88dc858cf47", async() => {
                BeginContext(1923, 106, true);
                WriteLiteral("\r\n                                <i class=\"large material-icons\">delete</i>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 41 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                                                                                                                                                                WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 41 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                                                                                                                                                                                               WriteLiteral(Url.RouteUrl(ViewContext.RouteData.Values));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnURL"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnURL", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnURL"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2033, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(2063, 338, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7054ec11777e490697ad95268cd9f51f", async() => {
                BeginContext(2293, 104, true);
                WriteLiteral("\r\n                                <i class=\"large material-icons\">info</i>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 44 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                                                                                                                                                          WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 44 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                                                                                                                                                                                         WriteLiteral(Url.RouteUrl(ViewContext.RouteData.Values));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnURL"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnURL", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnURL"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2401, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 47 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                             if (!usersMarkedAsMet.Contains(item.Id) || !usersMet.Contains(item.Id))
                            {

#line default
#line hidden
            BeginContext(2536, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(2568, 349, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a164c77313034a45814b69420b82e021", async() => {
                BeginContext(2795, 118, true);
                WriteLiteral("\r\n                                    <i class=\"large material-icons\">how_to_reg</i>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_14.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 49 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                                                                                                                                                           WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 49 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                                                                                                                                                                                          WriteLiteral(Url.RouteUrl(ViewContext.RouteData.Values));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnURL"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnURL", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnURL"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2917, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 52 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                            }

#line default
#line hidden
            BeginContext(2950, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 53 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                              
                                var goldStars = 3;
                            

#line default
#line hidden
            BeginContext(3065, 119, true);
            WriteLiteral("                            <div class=\"no-cursor\">\r\n                                <h4 class=\"card-title center\">\r\n\r\n");
            EndContext();
#line 59 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                     for (int i = 0; i < 5; i++)
                                    {
                                        if (i < goldStars)
                                        {

#line default
#line hidden
            BeginContext(3392, 100, true);
            WriteLiteral("                                            <a><i class=\"material-icons yellow-text\">grade</i></a>\r\n");
            EndContext();
#line 64 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(3624, 100, true);
            WriteLiteral("                                            <a><i class=\"material-icons white-text \">grade</i></a>\r\n");
            EndContext();
#line 68 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
                                        }
                                    }

#line default
#line hidden
            BeginContext(3806, 275, true);
            WriteLiteral(@"                                </h4>
                                <h6 class=""medium-small yellow-text center""><b>Rating</b></h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
");
            EndContext();
#line 77 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\Friendships\UserFriends.cshtml"
        }

#line default
#line hidden
            BeginContext(4092, 18, true);
            WriteLiteral("    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
