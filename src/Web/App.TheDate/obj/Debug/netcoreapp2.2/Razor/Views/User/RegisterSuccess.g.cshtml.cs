#pragma checksum "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\User\RegisterSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "424b402ed6c567e306f12cb3de4da43f76c5c3ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_RegisterSuccess), @"mvc.1.0.view", @"/Views/User/RegisterSuccess.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/RegisterSuccess.cshtml", typeof(AspNetCore.Views_User_RegisterSuccess))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"424b402ed6c567e306f12cb3de4da43f76c5c3ef", @"/Views/User/RegisterSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84759388a05de5888971c4975b65219621ff8a5c", @"/Views/_ViewImports.cshtml")]
    public class Views_User_RegisterSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\User\RegisterSuccess.cshtml"
  
    ViewData["Title"] = "Register Success";

#line default
#line hidden
            BeginContext(172, 46, true);
            WriteLiteral("\r\n\r\n\r\n<div class=\"container center\">\r\n    <h2>");
            EndContext();
            BeginContext(219, 17, false);
#line 10 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\User\RegisterSuccess.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(236, 209, true);
            WriteLiteral("</h2>\r\n    <p class=\"col s12 center-align\">\r\n        Check your inbox to confirm your mail!\r\n    </p>\r\n    <i class=\"material-icons green-text\" style=\"font-size:200px\">\r\n        sentiment_satisfied\r\n    </i>\r\n");
            EndContext();
#line 17 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\User\RegisterSuccess.cshtml"
     if (ViewBag.ReturnURL != null)
    {

#line default
#line hidden
            BeginContext(489, 25, true);
            WriteLiteral("        <br /><a class=\"\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 514, "\"", 539, 1);
#line 19 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\User\RegisterSuccess.cshtml"
WriteAttributeValue("", 521, ViewBag.ReturnURL, 521, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(540, 14, true);
            WriteLiteral(">Go Back</a>\r\n");
            EndContext();
#line 20 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\User\RegisterSuccess.cshtml"
    }

#line default
#line hidden
            BeginContext(561, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
