#pragma checksum "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37541a22ecabc0b46aaced4cd9a9594e6caa5d97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EducatorDash), @"mvc.1.0.view", @"/Views/Home/EducatorDash.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37541a22ecabc0b46aaced4cd9a9594e6caa5d97", @"/Views/Home/EducatorDash.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10646e181d9dd1f1db0de24aa5a7a8cb457b01d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EducatorDash : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VirtualClassroomDashboard.Models.CourseModel>>
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
#line 2 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
  
    ViewData["Title"] = "Educator Dashboard";
    Layout = "_LayoutEducator";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"one-hundred\">\r\n    <h1 class=\"mainHeading\">");
#nullable restore
#line 8 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    <p>If you would like to format your own email of concern please contact: <a class=""basicLinks"" href=""mailto: support@virtualclassroomdashboard.azurewebsites.net?subject=Issues or Concerns (Add your information here)&body=Message"">Support. </a>If you would like to format your own comment emil please contact: <a class=""basicLinks"" href=""mailto: info@virtualclassroomdashboard.azurewebsites.net?subject=IFeedback or Comments (Add your information here)&body=Message"">Info.</a></p>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "37541a22ecabc0b46aaced4cd9a9594e6caa5d975605", async() => {
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
            WriteLiteral("\r\n    <h2>Welcome ");
#nullable restore
#line 11 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
           Write(TempData["FN"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 11 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
                           Write(TempData["LN"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h2>\r\n\r\n");
#nullable restore
#line 13 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
     if (Model != null && TempData["SCI"] == "")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>Please Select a course to begin managing your classroom.</p>\r\n");
#nullable restore
#line 17 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>");
#nullable restore
#line 19 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
          Write(Html.ActionLink(item.CourseName + " " + item.CourseNumber, "SetCourse", new { id = item.CourseID }, new { @class = "courseButton" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <br />\r\n");
#nullable restore
#line 21 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
         
    }
    else if (TempData["SCI"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"selected\">Selected course: <b>");
#nullable restore
#line 25 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
                                           Write(TempData["SCI"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n        <p class=\"linkDec\">");
#nullable restore
#line 26 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
                      Write(Html.ActionLink("Select New Course", "selectNewCourse", new { @class = "submitButton" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <br />\r\n");
#nullable restore
#line 28 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>Something went wrong or you have not added any courses.</p>\r\n");
#nullable restore
#line 32 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\EducatorDash.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"clear\"></div>\r\n</div>\r\n<div class=\"clear\"></div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VirtualClassroomDashboard.Models.CourseModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
