#pragma checksum "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "caf86d3792183f4f9e3ffa15fb527409c2251660"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ImageComment_Index), @"mvc.1.0.view", @"/Views/ImageComment/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ImageComment/Index.cshtml", typeof(AspNetCore.Views_ImageComment_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caf86d3792183f4f9e3ffa15fb527409c2251660", @"/Views/ImageComment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"805b65725f9c98ebfddbadd6b3513a917bb782fa", @"/Views/_ViewImports.cshtml")]
    public class Views_ImageComment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ImageComment>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(77, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(106, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f4fe556663c4b128bd02796e1917381", async() => {
                BeginContext(129, 10, true);
                WriteLiteral("Create New");
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
            BeginContext(143, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(236, 38, false);
#line 16 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(274, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(330, 43, false);
#line 19 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Creator));

#line default
#line hidden
            EndContext();
            BeginContext(373, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(429, 49, false);
#line 22 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CommentedItem));

#line default
#line hidden
            EndContext();
            BeginContext(478, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(534, 43, false);
#line 25 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(577, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 31 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(695, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(744, 37, false);
#line 34 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(781, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(837, 45, false);
#line 37 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Creator.Id));

#line default
#line hidden
            EndContext();
            BeginContext(882, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(938, 51, false);
#line 40 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CommentedItem.Id));

#line default
#line hidden
            EndContext();
            BeginContext(989, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1045, 42, false);
#line 43 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Content));

#line default
#line hidden
            EndContext();
            BeginContext(1087, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1143, 65, false);
#line 46 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1208, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1229, 71, false);
#line 47 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1300, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1321, 69, false);
#line 48 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1390, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 51 "D:\Dokumenty\Inzynierka\Aplikacja\datingapplicationv2\DatingApplicationV2\Views\ImageComment\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1429, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ImageComment>> Html { get; private set; }
    }
}
#pragma warning restore 1591