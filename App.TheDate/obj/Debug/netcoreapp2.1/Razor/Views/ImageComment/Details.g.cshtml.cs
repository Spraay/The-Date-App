#pragma checksum "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6b8f2be21058de29c022ee8131b88ce7f2d94a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ImageComment_Details), @"mvc.1.0.view", @"/Views/ImageComment/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ImageComment/Details.cshtml", typeof(AspNetCore.Views_ImageComment_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6b8f2be21058de29c022ee8131b88ce7f2d94a6", @"/Views/ImageComment/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"805b65725f9c98ebfddbadd6b3513a917bb782fa", @"/Views/_ViewImports.cshtml")]
    public class Views_ImageComment_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ImageComment>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(21, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(66, 126, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>ImageComment</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(193, 38, false);
#line 14 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(231, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(275, 34, false);
#line 17 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(309, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(353, 43, false);
#line 20 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Creator));

#line default
#line hidden
            EndContext();
            BeginContext(396, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(440, 42, false);
#line 23 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
       Write(Html.DisplayFor(model => model.Creator.Id));

#line default
#line hidden
            EndContext();
            BeginContext(482, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(526, 49, false);
#line 26 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CommentedItem));

#line default
#line hidden
            EndContext();
            BeginContext(575, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(619, 48, false);
#line 29 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
       Write(Html.DisplayFor(model => model.CommentedItem.Id));

#line default
#line hidden
            EndContext();
            BeginContext(667, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(711, 43, false);
#line 32 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(754, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(798, 39, false);
#line 35 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
       Write(Html.DisplayFor(model => model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(837, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(885, 68, false);
#line 40 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(953, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(961, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e7d38c9ac71244d583f8837c079090f2", async() => {
                BeginContext(983, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(999, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ImageComment> Html { get; private set; }
    }
}
#pragma warning restore 1591
