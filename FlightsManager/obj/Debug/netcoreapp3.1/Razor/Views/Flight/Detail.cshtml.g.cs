#pragma checksum "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b47d6a459a550df5751d7a2a136b5dae8ac35f6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Flight_Detail), @"mvc.1.0.view", @"/Views/Flight/Detail.cshtml")]
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
#line 1 "D:\FlightsManager-Repo\FlightsManager\Views\_ViewImports.cshtml"
using FlightsManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FlightsManager-Repo\FlightsManager\Views\_ViewImports.cshtml"
using FlightsManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b47d6a459a550df5751d7a2a136b5dae8ac35f6c", @"/Views/Flight/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dbda67a6b2fa678c77c1acee670d59f69779ab6", @"/Views/_ViewImports.cshtml")]
    public class Views_Flight_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FlightsManager.Models.Flight.FlightDetailVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Detail</h1>

<table id=""table"">
    <thead>
        <tr>
            <th>First Name</th>
            <th>Middle Name</th>
            <th>Last Name</th>
            <th>Nationality</th>
            <th>PIN</th>
            <th>Email</th>
            <th>Telephone Number</th>
            <th>Ticket Type</th>
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 25 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
         foreach (var item in Model.Items)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
             foreach (var passanger in item.Items)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 30 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
                   Write(passanger.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
                   Write(passanger.MiddleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
                   Write(passanger.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
                   Write(passanger.Nationality);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
                   Write(passanger.PIN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 35 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
                   Write(passanger.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 36 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
                   Write(passanger.TelephoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
                   Write(passanger.TicketType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 39 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\FlightsManager-Repo\FlightsManager\Views\Flight\Detail.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FlightsManager.Models.Flight.FlightDetailVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
