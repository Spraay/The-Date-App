#pragma checksum "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Friendships\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "919302aa6033d9f594286164f62f45e892f3d7c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Friendships_Delete), @"mvc.1.0.view", @"/Views/Friendships/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Friendships/Delete.cshtml", typeof(AspNetCore.Views_Friendships_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"919302aa6033d9f594286164f62f45e892f3d7c7", @"/Views/Friendships/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84759388a05de5888971c4975b65219621ff8a5c", @"/Views/_ViewImports.cshtml")]
    public class Views_Friendships_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(13, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Friendships\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    var subheader = new SubHeaderViewModel()
    {
        Title = "Deleting friend",
        TitleIcon = "delete",
        TitleColour = "red-text",
        Message = "Are you sure you want to delete friendship with the person below?",
        MessageColor = "orange-text"
    };

#line default
#line hidden
            BeginContext(346, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(349, 48, false);
#line 15 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Friendships\Delete.cshtml"
Write(await Html.PartialAsync("_SubHeader", subheader));

#line default
#line hidden
            EndContext();
            BeginContext(397, 186, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col s4 offset-l4\">\r\n            <div class=\"card\">\r\n                <div class=\"card-image\">\r\n                    ");
            EndContext();
            BeginContext(583, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "919302aa6033d9f594286164f62f45e892f3d7c76073", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 593, "~/images/userimages/", 593, 20, true);
#line 22 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Friendships\Delete.cshtml"
AddHtmlAttributeValue("", 613, Html.DisplayFor(m=>Model.ProfileImageSrc), 613, 42, false);

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
            BeginContext(657, 125, true);
            WriteLiteral("\r\n                    <span class=\"card-title\" style=\"width:100%; background: rgba(0, 0, 0, 0.5);\">\r\n                        ");
            EndContext();
            BeginContext(783, 37, false);
#line 24 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Friendships\Delete.cshtml"
                   Write(Html.DisplayFor(m => Model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(820, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(823, 36, false);
#line 24 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Friendships\Delete.cshtml"
                                                           Write(Html.DisplayFor(m => Model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(859, 169, true);
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n                <div class=\"card-action grey\">\r\n                    <div class=\"center\">\r\n                        ");
            EndContext();
            BeginContext(1028, 562, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "919302aa6033d9f594286164f62f45e892f3d7c78791", async() => {
                BeginContext(1105, 32, true);
                WriteLiteral("\r\n                            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1137, "\"", 1162, 1);
#line 30 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Friendships\Delete.cshtml"
WriteAttributeValue("", 1144, ViewBag.ReturnURL, 1144, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1163, 420, true);
                WriteLiteral(@" class=""btn rounded btn-large waves-effect blue pulse"">
                                <i class=""material-icons"">replay</i>
                            </a>
                            <a id=""FormSubmitButton"" value=""Delete"" class=""btn btn-large waves-effect red pulse rounded"">
                                <i class=""material-icons"">delete_forever</i>
                            </a>
                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnURL", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 29 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Friendships\Delete.cshtml"
                                                                     WriteLiteral(ViewBag.ReturnURL);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnURL"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnURL", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnURL"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1590, 108, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
