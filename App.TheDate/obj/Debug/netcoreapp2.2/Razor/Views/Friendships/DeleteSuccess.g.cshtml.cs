#pragma checksum "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Friendships\DeleteSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c2d14bb9c0fc6893ca0040add7bba91f217aa00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Friendships_DeleteSuccess), @"mvc.1.0.view", @"/Views/Friendships/DeleteSuccess.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Friendships/DeleteSuccess.cshtml", typeof(AspNetCore.Views_Friendships_DeleteSuccess))]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#line 3 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\_ViewImports.cshtml"
using App.TheDate.Areas.Identity;

#line default
#line hidden
#line 4 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\_ViewImports.cshtml"
using App.Model.View;

#line default
#line hidden
#line 5 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\_ViewImports.cshtml"
using App.Model.Entities;

#line default
#line hidden
#line 6 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\_ViewImports.cshtml"
using App.Service.Abstract;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c2d14bb9c0fc6893ca0040add7bba91f217aa00", @"/Views/Friendships/DeleteSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b3d057190327018203cdc0549572cc79dc2002", @"/Views/_ViewImports.cshtml")]
    public class Views_Friendships_DeleteSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(13, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Friendships\DeleteSuccess.cshtml"
  
    ViewData["Title"] = "Friend delete confirmed";

#line default
#line hidden
            BeginContext(74, 475, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col s12"">
        <div class=""col s12 center""><i class=""material-icons green-text"" style=""font-size: 150px;"">sentiment_satisfied</i></div>
        <h1 class=""green-text center""> User below is not your friend now</h1>
    </div>
    <div class=""container"">
        <div class=""row"">
            <div class=""col s4 offset-l4"">
                <div class=""card"">
                    <div class=""card-image"">
                        ");
            EndContext();
            BeginContext(549, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9c2d14bb9c0fc6893ca0040add7bba91f217aa004627", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 559, "~/images/userimages/", 559, 20, true);
#line 17 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Friendships\DeleteSuccess.cshtml"
AddHtmlAttributeValue("", 579, Html.DisplayFor(m => Model.ProfileImageSrc), 579, 44, false);

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
            BeginContext(625, 103, true);
            WriteLiteral("\r\n                        <span class=\"card-title\" style=\"width:100%; background: rgba(0, 0, 0, 0.5);\">");
            EndContext();
            BeginContext(729, 37, false);
#line 18 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Friendships\DeleteSuccess.cshtml"
                                                                                                Write(Html.DisplayFor(m => Model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(766, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(768, 36, false);
#line 18 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Friendships\DeleteSuccess.cshtml"
                                                                                                                                       Write(Html.DisplayFor(m => Model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(804, 165, true);
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"card-action grey\">\r\n                        <div class=\"center\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 969, "\"", 994, 1);
#line 22 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Friendships\DeleteSuccess.cshtml"
WriteAttributeValue("", 976, ViewBag.ReturnURL, 976, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(995, 303, true);
            WriteLiteral(@" class=""btn rounded btn-large waves-effect blue pulse"">
                                <i class=""material-icons"">replay</i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
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
