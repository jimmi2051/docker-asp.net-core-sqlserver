#pragma checksum "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08d91771a7031bb1b7970708527176326efac6b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_ViewBook), @"mvc.1.0.view", @"/Views/Book/ViewBook.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Book/ViewBook.cshtml", typeof(AspNetCore.Views_Book_ViewBook))]
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
#line 1 "/home/deftnt/QL_Sach_SQL_part_2/Views/_ViewImports.cshtml"
using QL_Sach;

#line default
#line hidden
#line 2 "/home/deftnt/QL_Sach_SQL_part_2/Views/_ViewImports.cshtml"
using QL_Sach.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08d91771a7031bb1b7970708527176326efac6b2", @"/Views/Book/ViewBook.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c64d3f300bc488dbb353a64b96a1c43f7d048205", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_ViewBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QL_Sach.Models.Book>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
  
    ViewData["Title"] = "View Books";

#line default
#line hidden
            BeginContext(83, 464, true);
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <h2 style=""text-align:center;"">List Books </h2>
        <a href=""/Book/CreateBook"" class=""btn btn-danger"" style=""text-align:right;float:right; margin-bottom:15px;"">Add book</a>
<table class=""table"">
  <tr>
      <th>ID Book</th>
      <th>Name Book</th>
      <th>Author</th>
      <th>Num Pages</th>
      <th>Type Book</th>
      <th>PublishingCompany</th>
      <th>Price</th>
      <th>Action</th>
  </tr>
");
            EndContext();
#line 20 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
     foreach (var x in @Model)
    {

#line default
#line hidden
            BeginContext(584, 21, true);
            WriteLiteral("    <tr>\n        <td>");
            EndContext();
            BeginContext(606, 8, false);
#line 23 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
       Write(x.IdBook);

#line default
#line hidden
            EndContext();
            BeginContext(614, 18, true);
            WriteLiteral("</td>\n        <td>");
            EndContext();
            BeginContext(633, 10, false);
#line 24 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
       Write(x.NameBook);

#line default
#line hidden
            EndContext();
            BeginContext(643, 18, true);
            WriteLiteral("</td>\n        <td>");
            EndContext();
            BeginContext(662, 8, false);
#line 25 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
       Write(x.Author);

#line default
#line hidden
            EndContext();
            BeginContext(670, 18, true);
            WriteLiteral("</td>\n        <td>");
            EndContext();
            BeginContext(689, 9, false);
#line 26 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
       Write(x.NumPage);

#line default
#line hidden
            EndContext();
            BeginContext(698, 18, true);
            WriteLiteral("</td>\n        <td>");
            EndContext();
            BeginContext(717, 10, false);
#line 27 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
       Write(x.TypeBook);

#line default
#line hidden
            EndContext();
            BeginContext(727, 18, true);
            WriteLiteral("</td>\n        <td>");
            EndContext();
            BeginContext(746, 19, false);
#line 28 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
       Write(x.PublishingCompany);

#line default
#line hidden
            EndContext();
            BeginContext(765, 18, true);
            WriteLiteral("</td>\n        <td>");
            EndContext();
            BeginContext(784, 7, false);
#line 29 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
       Write(x.Price);

#line default
#line hidden
            EndContext();
            BeginContext(791, 33, true);
            WriteLiteral("</td>\n        <td>\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 824, "\"", 851, 2);
            WriteAttributeValue("", 831, "/Book/EditBook/", 831, 15, true);
#line 31 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
WriteAttributeValue("", 846, x.Id, 846, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(852, 24, true);
            WriteLiteral(">Edit</a>\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 876, "\"", 905, 2);
            WriteAttributeValue("", 883, "/Book/DeleteBook/", 883, 17, true);
#line 32 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
WriteAttributeValue("", 900, x.Id, 900, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(906, 36, true);
            WriteLiteral(">Delete</a>\n        </td>\n    </tr>\n");
            EndContext();
#line 35 "/home/deftnt/QL_Sach_SQL_part_2/Views/Book/ViewBook.cshtml"
    }

#line default
#line hidden
            BeginContext(948, 22, true);
            WriteLiteral("</table>\n</div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QL_Sach.Models.Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591
