#pragma checksum "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe0ff9283e03fe245d25be6b1e372e413f24c3a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewFiles), @"mvc.1.0.view", @"/Views/Home/ViewFiles.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe0ff9283e03fe245d25be6b1e372e413f24c3a6", @"/Views/Home/ViewFiles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10646e181d9dd1f1db0de24aa5a7a8cb457b01d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewFiles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VirtualClassroomDashboard.Models.CourseFileModel>>
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
#line 2 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
  
    ViewData["Title"] = "Files";
    string CurrentUID = @TempData["UID"].ToString();
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
#line 16 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    <p>If you would like to format your own email of concern please contact: <a class=""basicLinks"" href=""mailto: support@virtualclassroomdashboard.azurewebsites.net?subject=Issues or Concerns (Add your information here)&body=Message"">Support. </a>If you would like to format your own comment emil please contact: <a class=""basicLinks"" href=""mailto: info@virtualclassroomdashboard.azurewebsites.net?subject=IFeedback or Comments (Add your information here)&body=Message"">Info.</a></p>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fe0ff9283e03fe245d25be6b1e372e413f24c3a65758", async() => {
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
            WriteLiteral("\r\n\r\n    <h3>View/Add Files from ");
#nullable restore
#line 20 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                       Write(TempData["CourseName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 21 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
     if (@TempData["UT"].ToString() == "Teacher")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 23 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
      Write(Html.ActionLink("Add Files", "CourseFiles"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 24 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"errorResponse\">");
#nullable restore
#line 25 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                        Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 26 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
      
        if (ViewBag.Message == "Please got to the Dashboard and Select a Course. There is no active course selected.")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span style=\"color:red\">");
#nullable restore
#line 29 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                               Write(Html.Raw(ViewBag.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 30 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
             if (Model != null)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""tableDec"">
                    <tr>
                        <th>File Name</th>
                        <th>File Subject</th>
                        <th>File Description</th>
                        <th></th>

                    </tr>
");
#nullable restore
#line 44 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1952, "\"", 1987, 2);
#nullable restore
#line 47 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
WriteAttributeValue("", 1959, item.FIlePath, 1959, 14, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
WriteAttributeValue("", 1973, item.FileName, 1973, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" download>");
#nullable restore
#line 47 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                                                                                           Write(item.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                            <td>");
#nullable restore
#line 48 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                           Write(item.FileSubject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 49 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                           Write(item.FileDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 50 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                             if ((int.Parse(CurrentUID) == item.UserID) || @TempData["UT"].ToString() == "Teacher")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>");
#nullable restore
#line 52 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                               Write(Html.ActionLink("Remove", "RemoveUserFile", new { id = item.UserID, fname = item.FileName, fpath = item.FIlePath, cid = item.CourseID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 53 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 55 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n");
#nullable restore
#line 57 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>No Files have been uploaded for this course.</p>\r\n");
#nullable restore
#line 61 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\ViewFiles.cshtml"
             
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VirtualClassroomDashboard.Models.CourseFileModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
