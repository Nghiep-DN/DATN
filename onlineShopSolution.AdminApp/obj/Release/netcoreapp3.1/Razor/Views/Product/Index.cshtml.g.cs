#pragma checksum "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c061445bd996ed2be9fadfd8099328e9acae3b07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#nullable restore
#line 1 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
using onlineShopSolution.ViewModel.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c061445bd996ed2be9fadfd8099328e9acae3b07", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae5da72b613bc3d466e37d63efbe58e46967b9d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedResult<onlineShopSolution.ViewModel.Catalog.Products.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "categoryId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("this.form.submit()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Quản lý sản phẩm";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        setTimeout(function () {\r\n            $(\'#msgAlert\').fadeOut(\'slow\');\r\n        }, 2000);\r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"<!-- .content-wrapper -->
<div class=""content-wrapper"">

    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1>Quản lý sản phẩm</h1>
                </div>
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item""><a href=""#"">Trang chủ</a></li>
                        <li class=""breadcrumb-item active"">Quản lý sản phẩm</li>
                    </ol>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-12"">

                    <!-- /.card -->

                    <div class=""card"">
                        <div class=""card-header row"">");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n                            <div class=\"col-md-6 col-xs-12\">\r\n                                <p>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c061445bd996ed2be9fadfd8099328e9acae3b078389", async() => {
                WriteLiteral("Thêm mới");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </p>\r\n\r\n                            </div>\r\n                            <div class=\"col-md-6 col-xs-12\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c061445bd996ed2be9fadfd8099328e9acae3b0710015", async() => {
                WriteLiteral("\r\n\r\n                                    <div class=\"row\">\r\n                                        <div class=\"col-md-4\">\r\n                                            <input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 2154, "\"", 2178, 1);
#nullable restore
#line 59 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
WriteAttributeValue("", 2162, ViewBag.Keyword, 2162, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" name=\"keyword\" placeholder=\"Tìm kiếm theo tên sản phẩm\" />\r\n                                        </div>\r\n                                        <div class=\"col-md-4\">\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c061445bd996ed2be9fadfd8099328e9acae3b0711124", async() => {
                    WriteLiteral("\r\n                                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c061445bd996ed2be9fadfd8099328e9acae3b0711441", async() => {
                        WriteLiteral("--Chọn danh mục--");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 62 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Categories;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        </div>
                                        <div class=""col-md-4"">
                                            <button class=""btn btn-primary"" style=""border:solid 1px #808080"">
                                                <i class=""fas fa-search fa-fw""></i>
                                            </button>
                                            <button type=""button"" onclick=""window.location.href='/Product/Index'"" class=""btn btn-default"">Tạo lại</button>
                                        </div>
                                    </div>

                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n\r\n                        </div>\r\n                        <!-- /.card-header -->\r\n                        <div class=\"card-body\">\r\n\r\n");
#nullable restore
#line 81 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                             if (ViewBag.SuccessMsg != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div id=\"msgAlert\" class=\"alert alert-default-success\" role=\"alert\">\r\n                                    ");
#nullable restore
#line 84 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                               Write(ViewBag.SuccessMsg);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n");
#nullable restore
#line 86 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                            <table id=""example1"" class=""table table-bordered table-striped"">
                                <thead>
                                    <tr>
                                        <th>
                                            Id
                                        </th>
                                        <th>
                                            Tên
                                        </th>
                                        <th>
                                           Giá nhập
                                        </th>
                                        <th>
                                            Giá bán ra
                                        </th>
                                        <th>
                                            Số lượng
                                        </th>
                                        <th>
                                            Mô tả
                     ");
            WriteLiteral(@"                   </th>
                                        <th>
                                            Chi tiết
                                        </th>
                                        <th>
                                            SEO
                                        </th>
                                        <th>
                                            Hành động
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 122 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                     foreach (var item in Model.Items)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 126 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 129 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 132 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.OriginalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 135 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 138 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Stock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 141 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 144 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 147 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem=>item.SeoDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 150 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.ActionLink("Sửa", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                                ");
#nullable restore
#line 151 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.ActionLink("Chi tiết", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                                ");
#nullable restore
#line 152 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                           Write(Html.ActionLink("Xóa", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |  ");
#nullable restore
#line 152 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                                                                                      Write(Html.ActionLink("Gán danh mục", "CategoryAssign", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 155 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n\r\n                            </table>\r\n                            <br />\r\n\r\n                            ");
#nullable restore
#line 161 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Product\Index.cshtml"
                       Write(await Component.InvokeAsync("Pager", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </section>
    <!-- /.content -->

</div>
<!-- /.content-wrapper -->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedResult<onlineShopSolution.ViewModel.Catalog.Products.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
