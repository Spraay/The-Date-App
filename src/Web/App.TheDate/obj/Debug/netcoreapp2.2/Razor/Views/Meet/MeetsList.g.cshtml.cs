#pragma checksum "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5c044cd40b70ebca7a469a596f5dbf1902d030d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Meet_MeetsList), @"mvc.1.0.view", @"/Views/Meet/MeetsList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Meet/MeetsList.cshtml", typeof(AspNetCore.Views_Meet_MeetsList))]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#line 3 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\_ViewImports.cshtml"
using Web.TheDate.Areas.Identity;

#line default
#line hidden
#line 4 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\_ViewImports.cshtml"
using Core.Models.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\_ViewImports.cshtml"
using Core.Models.Entities;

#line default
#line hidden
#line 6 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\_ViewImports.cshtml"
using Core.Services.Abstract;

#line default
#line hidden
#line 7 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\_ViewImports.cshtml"
using Web.TheDate.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5c044cd40b70ebca7a469a596f5dbf1902d030d", @"/Views/Meet/MeetsList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84759388a05de5888971c4975b65219621ff8a5c", @"/Views/_ViewImports.cshtml")]
    public class Views_Meet_MeetsList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-large rounded blue tooltipped"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-position", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-tooltip", new global::Microsoft.AspNetCore.Html.HtmlString("Profile Details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-large rounded red lighten-1 tooltipped"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-tooltip", new global::Microsoft.AspNetCore.Html.HtmlString("Rate Authenticity"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Vote", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Vote", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
  
    ViewData["Title"] = "Real Life Met";

#line default
#line hidden
            BeginContext(77, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
 if (Model.Any())
{

#line default
#line hidden
            BeginContext(101, 372, true);
            WriteLiteral(@"    <div class=""grey darken-3 z-depth-3"" style=""padding: 1vw; margin-top: -10px;"">
        <div class=""center"">
            <p class=""white-text"" style=""font-size: 3vw;"">
                The users you've really met <i style=""vertical-align: bottom; font-size: 4vw !important;"" class=""inline-icon material-icons"">group</i>
            </p>
        </div>
    </div>
");
            EndContext();
#line 16 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(485, 311, true);
            WriteLiteral(@"    <div class=""valign-wrapper my-wrapper row"">
        <div class=""col s12"">
            <div class=""col s12 center""><i class=""material-icons orange-text"" style=""font-size: 150px;"">sentiment_dissatisfied</i></div>
            <h1 class=""orange-text center""> You did not meet anyone jet. 
                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 796, "\"", 821, 1);
#line 23 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
WriteAttributeValue("", 803, ViewBag.returnURL, 803, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(822, 184, true);
            WriteLiteral(" class=\"btn rounded btn-large waves-effect blue pulse\">\r\n                    <i class=\"material-icons\">replay</i>\r\n                </a>\r\n            </h1>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 29 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
}

#line default
#line hidden
            BeginContext(1009, 50, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 33 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1108, 147, true);
            WriteLiteral("            <div class=\"col m4\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-image inline\">\r\n                        ");
            EndContext();
            BeginContext(1255, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d5c044cd40b70ebca7a469a596f5dbf1902d030d9986", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1265, "~/images/userimages/", 1265, 20, true);
#line 38 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
AddHtmlAttributeValue("", 1285, Html.DisplayFor(m => item.ProfileImageSrc), 1285, 43, false);

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
            BeginContext(1331, 133, true);
            WriteLiteral("\r\n                        <span class=\"card-title\" style=\"width:100%; background: rgba(0, 0, 0, 0.5);\">\r\n                            ");
            EndContext();
            BeginContext(1465, 36, false);
#line 40 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
                       Write(Html.DisplayFor(m => item.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1501, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(1504, 35, false);
#line 40 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
                                                              Write(Html.DisplayFor(m => item.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1539, 189, true);
            WriteLiteral("\r\n                        </span>\r\n                    </div>\r\n                    <div class=\"card-action grey\">\r\n                        <div class=\"center\">\r\n                            ");
            EndContext();
            BeginContext(1728, 270, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5c044cd40b70ebca7a469a596f5dbf1902d030d12735", async() => {
                BeginContext(1896, 98, true);
                WriteLiteral("\r\n                                <i class=\"material-icons\">info</i>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 45 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
                                                                                                                                                                              WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1998, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(2028, 476, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5c044cd40b70ebca7a469a596f5dbf1902d030d15787", async() => {
                BeginContext(2203, 297, true);
                WriteLiteral(@"
                                <i class=""material-icons tiny yellow-text"">star</i>
                                <i class=""material-icons tiny yellow-text"">star_half</i>
                                <i class=""material-icons tiny yellow-text"">star_border</i>
                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
                                                                                                                                                                                     WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2504, 197, true);
            WriteLiteral("\r\n                            <p class=\"white red-text\">TODO is he marked me as met too</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 58 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Meet\MeetsList.cshtml"
        }

#line default
#line hidden
            BeginContext(2712, 18, true);
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
