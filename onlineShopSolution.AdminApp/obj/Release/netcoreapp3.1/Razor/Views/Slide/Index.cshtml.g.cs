#pragma checksum "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Slide\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8b20abd6a8c61c0b14709c32a4d09f8a283030d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Slide_Index), @"mvc.1.0.view", @"/Views/Slide/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8b20abd6a8c61c0b14709c32a4d09f8a283030d", @"/Views/Slide/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae5da72b613bc3d466e37d63efbe58e46967b9d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Slide_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Slide", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmValid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\IT-STUDY\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\Slide\Index.cshtml"
  
    ViewData["Title"] = " Quản lý slide";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    img {
        width: 100px;
        height: 100px;
    }
</style>
<link href=""/custom/customCss/category.css"" rel=""stylesheet"" />
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">


");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/custom/customJs/commonTable.js""></script>
    <script src=""/custom/customJs/pagination/jquery.twbsPagination.min.js""></script>
    <script src=""/custom/customJs/mustache/mustache.min.js""></script>
    <script src=""/plugins/jquery-validation/jquery.validate.min.js""></script>

    <script src=""/custom/customJs/slide/index.js""></script>
    <script src=""/plugins/sweetalert2/sweetalert2.all.js""></script>
    <script src=""/plugins/sweetalert2/sweetalert2.all.min.js""></script>
");
            }
            );
            WriteLiteral(@"<!-- Content Wrapper. Contains page content -->
<div class=""content-wrapper"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1>Quản lý slide</h1>
                </div>
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item""><a href=""#"">Trang chủ</a></li>
                        <li class=""breadcrumb-item active"">Quản lý silde</li>
                    </ol>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <section class=""content"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-header"">
");
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8b20abd6a8c61c0b14709c32a4d09f8a283030d7725", async() => {
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
            WriteLiteral(@"

                        </div>

                        <div class=""card-body"">
                            <table class=""table table-bordered table-hover"">
                                <thead>
                                    <tr>

                                        <th class=""sort_col_table"" scope=""col"">ID</th>
                                        <th class=""sort_col_table"" scope=""col"">
                                            Tên
                                            <i class=""fa fa-exchange fa-rotate-90"" aria-hidden=""true""></i>
                                        </th>
                                        <th class=""sort_col_table"" scope=""col"">
                                            Mô tả
                                            <i class=""fa fa-exchange fa-rotate-90"" aria-hidden=""true""></i>
                                        </th>

                                        <th class=""sort_col_table"" scope=""col"">
                               ");
            WriteLiteral(@"             Ảnh
                                            <i class=""fa fa-exchange fa-rotate-90"" aria-hidden=""true""></i>
                                        </th>
                                        <th class=""sort_col_table"" scope=""col"">
                                            Thứ tự
                                            <i class=""fa fa-exchange fa-rotate-90"" aria-hidden=""true""></i>
                                        </th>

                                        <th class=""sort_col_table"" scope=""col"">
                                            Hành động
                                            <i class=""fa fa-exchange fa-rotate-90"" aria-hidden=""true""></i>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th class=""search_col_table""></th>
                                        <th class=""search_col_table"">
                                      ");
            WriteLiteral("      <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 4168, "\"", 4175, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""myInputName"" onkeyup=""myFunctionSearchName()"">
                                            <i class=""fa fa-search"" aria-hidden=""true""></i>
                                        </th>
                                        <th class=""search_col_table"">
                                            <input type=""text""");
            BeginWriteAttribute("name", " name=\"", 4502, "\"", 4509, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""myInputName"" onkeyup=""myFunctionSearchName()"">
                                            <i class=""fa fa-search"" aria-hidden=""true""></i>
                                        </th>
                                        <th class=""search_col_table"">
                                            <input type=""text""");
            BeginWriteAttribute("name", " name=\"", 4836, "\"", 4843, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""myInputSeoAlias"" onkeyup=""myFunctionSearchSeoAlias()"">
                                            <i class=""fa fa-search"" aria-hidden=""true""></i>
                                        </th>
                                        <th class=""search_col_table"">
                                            <input type=""text""");
            BeginWriteAttribute("name", " name=\"", 5178, "\"", 5185, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""myInputSeoDescription"" onkeyup=""myFunctionSearchSeoDescription()"">
                                            <i class=""fa fa-search"" aria-hidden=""true""></i>
                                        </th>
                                        <th class=""search_col_table"">
                                            <input type=""text""");
            BeginWriteAttribute("name", " name=\"", 5532, "\"", 5539, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""myInputSeoTitle"" onkeyup=""myFunctionSearchSeoTitle()"">
                                            <i class=""fa fa-search"" aria-hidden=""true""></i>
                                        </th>

                                    </tr>
                                </thead>


                                <tbody id=""tblData"">
                                </tbody>
                            </table>
                            <br />
                            <div id=""pagination"" class=""pagination""></div>
                        </div>


                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->

                </div>
            </div>
        </div>
    </section>

</div>

<script id=""data-template"" type=""x-tmpl-mustache"">
                 <tr>

                     <td>{{ID}}</td>
                     <td>{{Name}}</td>
                     <td>{{Description}}</td>
                     <td> <img src=""{{Image}}""/");
            WriteLiteral(@"> </td>
                     <td>{{SortOrder}}</td>
                     <td>
                         <button class=""btn btn-outline-info btnDetail"" data-id=""{{ID}}"">Chi tiết </button>
                         <button class=""btn btn-outline-danger btnDelete"" data-id=""{{ID}}"">Xóa </button>
                     </td>
                </tr>
</script>


<!-- Modal -->
<div class=""modal fade"" id=""SlideModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Quản lý slide</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8b20abd6a8c61c0b14709c32a4d09f8a283030d15485", async() => {
                WriteLiteral(@"
                <div class=""modal-body"">
                    <input type=""hidden"" value=""0"" id=""hidID"">
                    <div class=""row"">
                        <div class=""col-md-3"">Tên:</div>
                        <div class=""col-md-9""><input id=""txtName"" name=""txtName"" required type=""text"" class=""form-control input-modal""");
                BeginWriteAttribute("value", " value=\"", 7879, "\"", 7887, 0);
                EndWriteAttribute();
                WriteLiteral(" /></div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-3\">Thứ tự:</div>\r\n                        <div class=\"col-md-9\"><input id=\"txtSortOrder\" type=\"text\" class=\"form-control input-modal\"");
                BeginWriteAttribute("value", " value=\"", 8142, "\"", 8150, 0);
                EndWriteAttribute();
                WriteLiteral(@" /></div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-3"">Ảnh:</div>
                        <div class=""col-md-9"">
                            <input type=""file"" id=""txtImage"" name=""txtImage"" class=""form-control"" />
                            <input type=""text"" style=""display:none"" id=""hidImage"" />
                        </div>
                    </div>
                    <br />
                    <div class=""row"">
                        <div class=""col-md-3"">Mô tả:</div>
                        <div class=""col-md-9"">
                            <textarea class=""form-control input-modal"" id=""txtDescription"" rows=""4""></textarea>

                        </div>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
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
            WriteLiteral(@"
            <div class=""modal-footer"">
                <button type=""submit"" id=""btnSave"" class=""btn btn-outline-success"">Lưu</button>
                <button type=""button"" class=""btn btn-outline-danger"" data-dismiss=""modal"">Thoát</button>
            </div>
        </div>
    </div>
</div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591