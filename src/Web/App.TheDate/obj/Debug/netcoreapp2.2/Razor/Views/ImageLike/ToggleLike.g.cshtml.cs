#pragma checksum "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\ImageLike\ToggleLike.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05f3d4a5d5bad0ee58e5adc89c1c5eb0d7b2321a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ImageLike_ToggleLike), @"mvc.1.0.view", @"/Views/ImageLike/ToggleLike.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ImageLike/ToggleLike.cshtml", typeof(AspNetCore.Views_ImageLike_ToggleLike))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05f3d4a5d5bad0ee58e5adc89c1c5eb0d7b2321a", @"/Views/ImageLike/ToggleLike.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84759388a05de5888971c4975b65219621ff8a5c", @"/Views/_ViewImports.cshtml")]
    public class Views_ImageLike_ToggleLike : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Image>
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
            BeginContext(14, 98, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col s12\">\r\n        <h1 class=\"green-text center\">\r\n            ");
            EndContext();
            BeginContext(114, 69, false);
#line 5 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\ImageLike\ToggleLike.cshtml"
        Write(ViewBag.isLiked ? "You liked image below" : "You unliked image below");

#line default
#line hidden
            EndContext();
            BeginContext(184, 235, true);
            WriteLiteral("\r\n        </h1>\r\n    </div>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col s4 offset-l4\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-image\">\r\n                        ");
            EndContext();
            BeginContext(419, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "05f3d4a5d5bad0ee58e5adc89c1c5eb0d7b2321a4791", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 429, "~/images/userimages/", 429, 20, true);
#line 13 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\ImageLike\ToggleLike.cshtml"
AddHtmlAttributeValue("", 449, Model.Src, 449, 10, false);

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
            BeginContext(461, 103, true);
            WriteLiteral("\r\n                        <span class=\"card-title\" style=\"width:100%; background: rgba(0, 0, 0, 0.5);\">");
            EndContext();
            BeginContext(565, 11, false);
#line 14 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\ImageLike\ToggleLike.cshtml"
                                                                                                Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(576, 165, true);
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"card-action grey\">\r\n                        <div class=\"center\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 741, "\"", 766, 1);
#line 18 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\ImageLike\ToggleLike.cshtml"
WriteAttributeValue("", 748, ViewBag.returnURL, 748, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(767, 299, true);
            WriteLiteral(@" class=""btn rounded btn-large waves-effect blue pulse"">
                                <i class=""material-icons"">replay</i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Image> Html { get; private set; }
    }
}
#pragma warning restore 1591
