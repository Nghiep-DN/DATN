#pragma checksum "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Shared\Components\Navigation\Navigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1624e137ab5b66b406f1c762c5651a55f0a552ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Navigation_Navigation), @"mvc.1.0.view", @"/Views/Shared/Components/Navigation/Navigation.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\_ViewImports.cshtml"
using onlineShopSolution.AdminApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\_ViewImports.cshtml"
using onlineShopSolution.AdminApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1624e137ab5b66b406f1c762c5651a55f0a552ba", @"/Views/Shared/Components/Navigation/Navigation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae5da72b613bc3d466e37d63efbe58e46967b9d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Navigation_Navigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NavigationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline ml-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("this.form.submit()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmChangeLanguage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/home/language"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<!-- Navbar -->
<nav class=""main-header navbar navbar-expand navbar-white navbar-light"">
    <!-- Left navbar links -->
    <ul class=""navbar-nav"">
        <li class=""nav-item"">
            <a class=""nav-link"" data-widget=""pushmenu"" href=""#"" role=""button""><i class=""fas fa-bars""></i></a>
        </li>
        <li class=""nav-item d-none d-sm-inline-block"">
            <a href=""index3.html"" class=""nav-link"">Home</a>
        </li>
        <li class=""nav-item d-none d-sm-inline-block"">
            <a href=""#"" class=""nav-link"">Contact</a>
        </li>
    </ul>

    <!-- SEARCH FORM -->
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1624e137ab5b66b406f1c762c5651a55f0a552ba6308", async() => {
                WriteLiteral(@"
        <div class=""input-group input-group-sm"">
            <input class=""form-control form-control-navbar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
            <div class=""input-group-append"">
                <button class=""btn btn-navbar"" type=""submit"">
                    <i class=""fas fa-search""></i>
                </button>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <!-- Right navbar links -->
    <ul class=""navbar-nav ml-auto"">
        <!-- Messages Dropdown Menu -->
        <li class=""nav-item dropdown"">
            <a class=""nav-link"" data-toggle=""dropdown"" href=""#"">
                <i class=""far fa-comments""></i>
                <span class=""badge badge-danger navbar-badge"">3</span>
            </a>
            <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"">
                <a href=""#"" class=""dropdown-item"">
                    <!-- Message Start -->
                    <div class=""media"">
                        <img src=""/dist/img/user1-128x128.jpg"" alt=""User Avatar"" class=""img-size-50 mr-3 img-circle"">
                        <div class=""media-body"">
                            <h3 class=""dropdown-item-title"">
                                Brad Diesel
                                <span class=""float-right text-sm text-danger""><i class=""fas fa-star""></i></span>
                            </h3>
                        ");
            WriteLiteral(@"    <p class=""text-sm"">Call me whenever you can...</p>
                            <p class=""text-sm text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                        </div>
                    </div>
                    <!-- Message End -->
                </a>
                <div class=""dropdown-divider""></div>
                <a href=""#"" class=""dropdown-item"">
                    <!-- Message Start -->
                    <div class=""media"">
                        <img src=""/dist/img/user8-128x128.jpg"" alt=""User Avatar"" class=""img-size-50 img-circle mr-3"">
                        <div class=""media-body"">
                            <h3 class=""dropdown-item-title"">
                                John Pierce
                                <span class=""float-right text-sm text-muted""><i class=""fas fa-star""></i></span>
                            </h3>
                            <p class=""text-sm"">I got your message bro</p>
                            <p class=""text-sm");
            WriteLiteral(@" text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                        </div>
                    </div>
                    <!-- Message End -->
                </a>
                <div class=""dropdown-divider""></div>
                <a href=""#"" class=""dropdown-item"">
                    <!-- Message Start -->
                    <div class=""media"">
                        <img src=""/dist/img/user3-128x128.jpg"" alt=""User Avatar"" class=""img-size-50 img-circle mr-3"">
                        <div class=""media-body"">
                            <h3 class=""dropdown-item-title"">
                                Nora Silvester
                                <span class=""float-right text-sm text-warning""><i class=""fas fa-star""></i></span>
                            </h3>
                            <p class=""text-sm"">The subject goes here</p>
                            <p class=""text-sm text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                        </div>
 ");
            WriteLiteral(@"                   </div>
                    <!-- Message End -->
                </a>
                <div class=""dropdown-divider""></div>
                <a href=""#"" class=""dropdown-item dropdown-footer"">See All Messages</a>
            </div>
        </li>
        <!-- Notifications Dropdown Menu -->
        <li class=""nav-item dropdown"">
            <a class=""nav-link"" data-toggle=""dropdown"" href=""#"">
                <i class=""far fa-bell""></i>
                <span class=""badge badge-warning navbar-badge"">15</span>
            </a>
            <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"">
                <span class=""dropdown-item dropdown-header"">15 Notifications</span>
                <div class=""dropdown-divider""></div>
                <a href=""#"" class=""dropdown-item"">
                    <i class=""fas fa-envelope mr-2""></i> 4 new messages
                    <span class=""float-right text-muted text-sm"">3 mins</span>
                </a>
                <div cl");
            WriteLiteral(@"ass=""dropdown-divider""></div>
                <a href=""#"" class=""dropdown-item"">
                    <i class=""fas fa-users mr-2""></i> 8 friend requests
                    <span class=""float-right text-muted text-sm"">12 hours</span>
                </a>
                <div class=""dropdown-divider""></div>
                <a href=""#"" class=""dropdown-item"">
                    <i class=""fas fa-file mr-2""></i> 3 new reports
                    <span class=""float-right text-muted text-sm"">2 days</span>
                </a>
                <div class=""dropdown-divider""></div>
                <a href=""#"" class=""dropdown-item dropdown-footer"">See All Notifications</a>
            </div>
        </li>


        <!-- Notifications Dropdown Menu -->
        <li class=""nav-item dropdown"">
            <a class=""nav-link"" data-toggle=""dropdown"" href=""#"">
                <i class=""fa fa-language""></i>
                <span class=""badge badge-success navbar-badge"">2</span>
            </a>
           ");
            WriteLiteral(" <div class=\"dropdown-menu dropdown-menu-lg dropdown-menu-right\">\r\n                <span class=\"dropdown-item dropdown-header\">Languages</span>\r\n\r\n");
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1624e137ab5b66b406f1c762c5651a55f0a552ba13677", async() => {
                WriteLiteral("\r\n\r\n                <input type=\"hidden\" name=\"ReturnUrl\"");
                BeginWriteAttribute("value", " value=\"", 6755, "\"", 6784, 1);
#nullable restore
#line 136 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Shared\Components\Navigation\Navigation.cshtml"
WriteAttributeValue("", 6763, Context.Request.Path, 6763, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1624e137ab5b66b406f1c762c5651a55f0a552ba14455", async() => {
                    WriteLiteral("\r\n\r\n");
                    WriteLiteral("\r\n\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 137 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Shared\Components\Navigation\Navigation.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CurrentLanguageId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 137 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Shared\Components\Navigation\Navigation.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.Languages;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            

                <div class=""dropdown-divider""></div>
                <a href=""#"" class=""dropdown-item dropdown-footer"">See more</a>
            </div>
        </li>


        <li class=""nav-item"">
            <a class=""nav-link"" data-widget=""fullscreen"" href=""#"" role=""button"">
                <i class=""fas fa-expand-arrows-alt""></i>
            </a>
        </li>
        <li class=""nav-item"">
            <a class=""nav-link"" data-widget=""control-sidebar"" data-slide=""true"" href=""#"" role=""button"">
                <i class=""fas fa-th-large""></i>
            </a>
        </li>
    </ul>
</nav>
<!-- /.navbar -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NavigationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
