#pragma checksum "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a219d3c34b880cf2df2b4c177a478ea138256a8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Roster), @"mvc.1.0.view", @"/Views/Home/Roster.cshtml")]
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
#line 1 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\_ViewImports.cshtml"
using VirtualClassroomDashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\_ViewImports.cshtml"
using VirtualClassroomDashboard.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a219d3c34b880cf2df2b4c177a478ea138256a8d", @"/Views/Home/Roster.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10646e181d9dd1f1db0de24aa5a7a8cb457b01d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Roster : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VirtualClassroomDashboard.Models.UserModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("centerDivide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/centerDividers.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Virtual Classroom Dashboard Center Divider"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
  
    ViewData["Title"] = "Roster";
    if (@TempData["UT"].ToString() == "Student")
    {
        Layout = "_LayoutStudent";
    }
    else
    {
        Layout = "_LayoutEducator";
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"one-hundred\">\r\n    <h1 class=\"mainHeading\">");
#nullable restore
#line 16 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    <p>If you would like to format your own email of concern please contact: <a class=""basicLinks"" href=""mailto: support@virtualclassroomdashboard.azurewebsites.net?subject=Issues or Concerns (Add your information here)&body=Message"">Support. </a>If you would like to format your own comment emil please contact: <a class=""basicLinks"" href=""mailto: info@virtualclassroomdashboard.azurewebsites.net?subject=IFeedback or Comments (Add your information here)&body=Message"">Info.</a></p>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a219d3c34b880cf2df2b4c177a478ea138256a8d5680", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <h2>");
#nullable restore
#line 19 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
   Write(TempData["CourseName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n    <p class=\"errorResponse\">");
#nullable restore
#line 21 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                        Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 22 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
     if (Model != null)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <table class=\"tableDec\">\r\n            <tr>\r\n                <th>User Id</th>\r\n                <th>First Name</th>\r\n                <th>Last Name </th>\r\n                <th>Email Address</th>\r\n                <th>PhoneNumber</th>\r\n");
#nullable restore
#line 32 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                 if (@TempData["UT"].ToString() == "Teacher")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th></th>\r\n");
#nullable restore
#line 35 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n            </tr>\r\n");
#nullable restore
#line 38 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n");
#nullable restore
#line 41 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                      if (@TempData["UT"].ToString() == "Teacher")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 43 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                       Write(item.UserID.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 44 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 45 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                   Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 46 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                   Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 47 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                   Write(item.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 48 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                   Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 49 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                     if (@TempData["UT"].ToString() == "Teacher")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 51 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                       Write(Html.ActionLink("Remove", "RemoveStudent", new { id = item.UserID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 52 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 55 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 57 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>There are no Students enrolled in this course. Or you have not selected a course on the dashboard</p>\r\n");
#nullable restore
#line 61 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Roster.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class = \"clear\"></div>\r\n</div>\r\n<div class=\"clear\"></div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VirtualClassroomDashboard.Models.UserModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
