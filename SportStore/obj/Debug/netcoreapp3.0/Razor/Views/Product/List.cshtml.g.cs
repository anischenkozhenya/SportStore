#pragma checksum "E:\sportstore\SportStore\SportStore\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a9e9b7ede491ba5de7d67cc87d3fe3470547678"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/List.cshtml", typeof(AspNetCore.Views_Product_List))]
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
#line 1 "E:\sportstore\SportStore\SportStore\Views\_ViewImports.cshtml"
using SportStore.Models;

#line default
#line hidden
#line 2 "E:\sportstore\SportStore\SportStore\Views\_ViewImports.cshtml"
using SportStore.Models.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a9e9b7ede491ba5de7d67cc87d3fe3470547678", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11861064903b8f7ae9a36ded2e5db7277307e191", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductsListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\sportstore\SportStore\SportStore\Views\Product\List.cshtml"
 foreach (var p in Model.Products)
{

#line default
#line hidden
            BeginContext(69, 23, true);
            WriteLiteral("    <div>\r\n        <h3>");
            EndContext();
            BeginContext(93, 6, false);
#line 5 "E:\sportstore\SportStore\SportStore\Views\Product\List.cshtml"
       Write(p.Name);

#line default
#line hidden
            EndContext();
            BeginContext(99, 15, true);
            WriteLiteral("</h3>\r\n        ");
            EndContext();
            BeginContext(115, 13, false);
#line 6 "E:\sportstore\SportStore\SportStore\Views\Product\List.cshtml"
   Write(p.Description);

#line default
#line hidden
            EndContext();
            BeginContext(128, 14, true);
            WriteLiteral("\r\n        <h4>");
            EndContext();
            BeginContext(143, 21, false);
#line 7 "E:\sportstore\SportStore\SportStore\Views\Product\List.cshtml"
       Write(p.Price.ToString("c"));

#line default
#line hidden
            EndContext();
            BeginContext(164, 19, true);
            WriteLiteral("</h4>\r\n    </div>\r\n");
            EndContext();
#line 9 "E:\sportstore\SportStore\SportStore\Views\Product\List.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductsListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
