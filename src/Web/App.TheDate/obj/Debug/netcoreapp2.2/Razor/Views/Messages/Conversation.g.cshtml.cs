#pragma checksum "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1776ac62c2f7b3b67d906d237d1a0cdd066267e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Messages_Conversation), @"mvc.1.0.view", @"/Views/Messages/Conversation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Messages/Conversation.cshtml", typeof(AspNetCore.Views_Messages_Conversation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1776ac62c2f7b3b67d906d237d1a0cdd066267e2", @"/Views/Messages/Conversation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84759388a05de5888971c4975b65219621ff8a5c", @"/Views/_ViewImports.cshtml")]
    public class Views_Messages_Conversation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Conversation>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("grey-text pointer-cursor"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Conversations", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 40px; height: 40px; position: relative; left: -45px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/app.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
  
    ViewData["Title"] = "Conversation";
    IEnumerable<User> conversationUsers = ViewBag.ConversationUsers;
    IEnumerable<Message> messages = Model.Messages.OrderBy(_ => _.CreatedDate);
    bool isOwner(Message msg)
    {
        return msg.Sender.UserName == User.Identity.Name;
    }

#line default
#line hidden
            BeginContext(324, 537, true);
            WriteLiteral(@"<div class=""hide-on-small-and-down"">
    <br />
</div>
<div class=""row"">
    <div id=""conversationMessagesWindow"" class=""section col s12 m8 l6 offset-m2 offset-l3 white z-depth-2 red"">
        <div id=""CMWHeader"" class=""row section"">
            <div class=""col s12"">
                <div class=""col s12"">
                    <div class=""col s6 left"">
                        <h6 class=""grey-text"" id=""cName""></h6>
                    </div>
                    <div class=""col s6 valign right "">
                        <h6>");
            EndContext();
            BeginContext(861, 238, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1776ac62c2f7b3b67d906d237d1a0cdd066267e27586", async() => {
                BeginContext(1037, 58, true);
                WriteLiteral("<i class=\"material-icons right hover-opacity\">settings</i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 23 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
                                                                                                                   WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 23 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
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
            BeginContext(1099, 387, true);
            WriteLiteral(@"</h6>
                    </div>
                </div>
                <ul class=""collapsible z-depth-0 no-border"">
                    <li>
                        <h8 class=""collapsible-header no-border z-depth-0 grey-text""><i class=""material-icons"">group</i>Conversation users...</h8>
                        <div class=""collapsible-body col s12"">
                            ");
            EndContext();
            BeginContext(1487, 57, false);
#line 30 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
                       Write(await Html.PartialAsync("_UsersChips", conversationUsers));

#line default
#line hidden
            EndContext();
            BeginContext(1544, 264, true);
            WriteLiteral(@"
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <div id=""CMWContent"" class=""row section"" style=""overflow-y:scroll; max-width: 100%; overflow-x: hidden; height:400px; padding: 10px;"">
");
            EndContext();
#line 37 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
             for (int i = 0; i < messages.Count(); i++)
            {
                var current = messages.ElementAtOrDefault(i);
                var next = messages.ElementAtOrDefault(i + 1);
                var iO = isOwner(current);

#line default
#line hidden
            BeginContext(2051, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2071, "\"", 2136, 1);
#line 42 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
WriteAttributeValue("", 2076, current==messages.LastOrDefault()?"lastMessage":"message", 2076, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2137, 70, true);
            WriteLiteral(" class=\"col s12\" style=\"margin-left: 20px;\">\r\n                    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2207, "\"", 2242, 3);
            WriteAttributeValue("", 2215, "col", 2215, 3, true);
            WriteAttributeValue(" ", 2218, "s6", 2219, 3, true);
#line 43 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
WriteAttributeValue(" ", 2221, iO?"offset-s6":"", 2222, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2243, 79, true);
            WriteLiteral(">\r\n                        <div style=\"display: inline-block; margin-top: 4px;\"");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2322, "\"", 2411, 2);
            WriteAttributeValue("", 2330, "rounded", 2330, 7, true);
#line 44 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
WriteAttributeValue(" ", 2337, iO?"right left-align blue white-text":"left left-align grey lighten-2", 2338, 73, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2412, 98, true);
            WriteLiteral(">\r\n                            <div style=\"padding: 4px;  margin-left: 10px; margin-right: 10px;\">");
            EndContext();
            BeginContext(2511, 15, false);
#line 45 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
                                                                                          Write(current.Content);

#line default
#line hidden
            EndContext();
            BeginContext(2526, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 46 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
                             if (!isOwner(current) && (next == null || next.SenderId != current.SenderId))
                            {

#line default
#line hidden
            BeginContext(2673, 36, true);
            WriteLiteral("                                <div");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2709, "\"", 2746, 1);
#line 48 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
WriteAttributeValue("", 2717, iO?"":"margin-top: -40px;", 2717, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2747, 39, true);
            WriteLiteral(">\r\n                                    ");
            EndContext();
            BeginContext(2786, 155, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1776ac62c2f7b3b67d906d237d1a0cdd066267e215839", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2796, "~/images/userimages/", 2796, 20, true);
#line 49 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
AddHtmlAttributeValue("", 2816, current.Sender.ProfileImageSrc, 2816, 31, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2941, 42, true);
            WriteLiteral("\r\n                                </div>\r\n");
            EndContext();
#line 51 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
                            }

#line default
#line hidden
            BeginContext(3014, 84, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 55 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
            }

#line default
#line hidden
            BeginContext(3113, 128, true);
            WriteLiteral("        </div>\r\n        <div id=\"CMWFooter\" class=\"section\">\r\n            <div class=\"valign-wrapper col s12\">\r\n                ");
            EndContext();
            BeginContext(3242, 84, false);
#line 59 "C:\Users\Spray\Desktop\The-Date-App\src\Web\App.TheDate\Views\Messages\Conversation.cshtml"
           Write(await Html.PartialAsync("_MessageForm", new Message() { ConversationId = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(3326, 60, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(3386, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1776ac62c2f7b3b67d906d237d1a0cdd066267e218986", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3426, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Conversation> Html { get; private set; }
    }
}
#pragma warning restore 1591
