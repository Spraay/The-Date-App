#pragma checksum "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d2f807b50fa5da9875e3da177b0512639eea924"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Navbar__NavBar), @"mvc.1.0.view", @"/Views/Shared/Navbar/_NavBar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Navbar/_NavBar.cshtml", typeof(AspNetCore.Views_Shared_Navbar__NavBar))]
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
using DatingApplicationV2.Areas.Identity;

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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d2f807b50fa5da9875e3da177b0512639eea924", @"/Views/Shared/Navbar/_NavBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"805b65725f9c98ebfddbadd6b3513a917bb782fa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Navbar__NavBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("brand-logo center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size: 3vw"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
 if (@Url.RouteUrl(ViewContext.RouteData.Values) == "/")
{

#line default
#line hidden
            BeginContext(106, 167, true);
            WriteLiteral("    <div class=\"navbar-fixed\">\r\n        <nav class=\"z-depth-1\" style=\"background-color: rgba(0, 0, 0, 0.1);\">\r\n            <div class=\"nav-wrapper \">\r\n                ");
            EndContext();
            BeginContext(273, 459, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d2f807b50fa5da9875e3da177b0512639eea9246502", async() => {
                BeginContext(366, 362, true);
                WriteLiteral(@"
                    <i class=""material-icons left"" style=""font-size: 3vw; margin-top:1px;"">
                        favorite_border
                    </i>
                    The Date
                    <i class=""material-icons right"" style=""font-size: 3vw; margin-top:1px;"">
                        favorite
                    </i>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(732, 198, true);
            WriteLiteral("\r\n                <a href=\"#\" data-target=\"slide-out\" class=\"sidenav-trigger\"><i class=\"material-icons\">menu</i></a>\r\n                <ul id=\"nav-mobile\" class=\"right hide-on-med-and-down inline\">\r\n");
            EndContext();
#line 19 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                     if (SignInManager.IsSignedIn(User))
                    {
                        

#line default
#line hidden
            BeginContext(1036, 51, false);
#line 21 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/Dropdown/_Profile"));

#line default
#line hidden
            EndContext();
            BeginContext(1114, 54, false);
#line 22 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/Dropdown/_Friendship"));

#line default
#line hidden
            EndContext();
            BeginContext(1195, 52, false);
#line 23 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/Dropdown/_Messages"));

#line default
#line hidden
            EndContext();
            BeginContext(1274, 52, false);
#line 24 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/Dropdown/_Settings"));

#line default
#line hidden
            EndContext();
            BeginContext(1353, 41, false);
#line 25 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/_LogOut"));

#line default
#line hidden
            EndContext();
#line 25 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                                                                  
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1468, 28, true);
            WriteLiteral("                        <li>");
            EndContext();
            BeginContext(1496, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d2f807b50fa5da9875e3da177b0512639eea92410833", async() => {
                BeginContext(1548, 8, true);
                WriteLiteral("Register");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1560, 35, true);
            WriteLiteral("</li>\r\n                        <li>");
            EndContext();
            BeginContext(1595, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d2f807b50fa5da9875e3da177b0512639eea92412440", async() => {
                BeginContext(1644, 5, true);
                WriteLiteral("Login");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1653, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 31 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                    }

#line default
#line hidden
            BeginContext(1683, 71, true);
            WriteLiteral("                </ul>\r\n            </div>\r\n        </nav>\r\n    </div>\r\n");
            EndContext();
#line 36 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1766, 112, true);
            WriteLiteral("    <div class=\"navbar-fixed\">\r\n        <nav class=\"\">\r\n            <div class=\"nav-wrapper \">\r\n                ");
            EndContext();
            BeginContext(1878, 459, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d2f807b50fa5da9875e3da177b0512639eea92414709", async() => {
                BeginContext(1971, 362, true);
                WriteLiteral(@"
                    <i class=""material-icons left"" style=""font-size: 3vw; margin-top:1px;"">
                        favorite_border
                    </i>
                    The Date
                    <i class=""material-icons right"" style=""font-size: 3vw; margin-top:1px;"">
                        favorite
                    </i>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2337, 194, true);
            WriteLiteral("\r\n                <a href=\"#\" data-target=\"slide-out\" class=\"sidenav-trigger\"><i class=\"material-icons\">menu</i></a>\r\n                <ul class=\"left hide-on-med-and-down\">\r\n                    ");
            EndContext();
            BeginContext(2532, 42, false);
#line 53 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
               Write(await Html.PartialAsync("Navbar/_Explore"));

#line default
#line hidden
            EndContext();
            BeginContext(2574, 105, true);
            WriteLiteral("\r\n                </ul>\r\n                <ul id=\"nav-mobile\" class=\"right hide-on-med-and-down inline\">\r\n");
            EndContext();
#line 56 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                     if (SignInManager.IsSignedIn(User))
                    {
                        

#line default
#line hidden
            BeginContext(2785, 51, false);
#line 58 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/Dropdown/_Profile"));

#line default
#line hidden
            EndContext();
            BeginContext(2863, 54, false);
#line 59 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/Dropdown/_Friendship"));

#line default
#line hidden
            EndContext();
            BeginContext(2944, 52, false);
#line 60 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/Dropdown/_Messages"));

#line default
#line hidden
            EndContext();
            BeginContext(3023, 52, false);
#line 61 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/Dropdown/_Settings"));

#line default
#line hidden
            EndContext();
            BeginContext(3102, 41, false);
#line 62 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                   Write(await Html.PartialAsync("Navbar/_LogOut"));

#line default
#line hidden
            EndContext();
#line 62 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                                                                  
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(3217, 28, true);
            WriteLiteral("                        <li>");
            EndContext();
            BeginContext(3245, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d2f807b50fa5da9875e3da177b0512639eea92419518", async() => {
                BeginContext(3297, 8, true);
                WriteLiteral("Register");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3309, 35, true);
            WriteLiteral("</li>\r\n                        <li>");
            EndContext();
            BeginContext(3344, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d2f807b50fa5da9875e3da177b0512639eea92421125", async() => {
                BeginContext(3393, 5, true);
                WriteLiteral("Login");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3402, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 68 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
                    }

#line default
#line hidden
            BeginContext(3432, 71, true);
            WriteLiteral("                </ul>\r\n            </div>\r\n        </nav>\r\n    </div>\r\n");
            EndContext();
#line 73 "C:\Users\Spray\Desktop\The-Date-App\App.TheDate\Views\Shared\Navbar\_NavBar.cshtml"
}

#line default
#line hidden
            BeginContext(3506, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<User> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591