#pragma checksum "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b325a7590fa748e92c91e61c46092dc5ce0055dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Discussions), @"mvc.1.0.view", @"/Views/Home/Discussions.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b325a7590fa748e92c91e61c46092dc5ce0055dd", @"/Views/Home/Discussions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10646e181d9dd1f1db0de24aa5a7a8cb457b01d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Discussions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VirtualClassroomDashboard.Models.DiscussionsModel>>
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
#line 2 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
  
    ViewData["Title"] = "Discussions";
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
#line 16 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    <p>If you would like to format your own email of concern please contact: <a class=""basicLinks"" href=""mailto: support@virtualclassroomdashboard.azurewebsites.net?subject=Issues or Concerns (Add your information here)&body=Message"">Support. </a>If you would like to format your own comment emil please contact: <a class=""basicLinks"" href=""mailto: info@virtualclassroomdashboard.azurewebsites.net?subject=IFeedback or Comments (Add your information here)&body=Message"">Info.</a></p>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b325a7590fa748e92c91e61c46092dc5ce0055dd5779", async() => {
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
            WriteLiteral("\r\n\r\n    <h2>Discussion Board for ");
#nullable restore
#line 20 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                        Write(TempData["CourseName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 21 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
     if (@TempData["UT"].ToString() == "Teacher")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"linkDec\">");
#nullable restore
#line 23 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                      Write(Html.ActionLink("Add Discussion Board", "AddDiscussion"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 24 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"errorResponse\">");
#nullable restore
#line 25 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                        Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 26 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
      
        if (ViewBag.Message == "Please go to the Dashboard and Select a Course. There is no active course selected.")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span style=\"color:red\">");
#nullable restore
#line 29 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                               Write(Html.Raw(ViewBag.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 30 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
             if (Model != null)
            {

                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                 foreach (var item in Model)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"discussboard\">\r\n                        <p class=\"db\">");
#nullable restore
#line 40 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                                 Write(Html.ActionLink(item.DiscussionTitle, "Discussion", new { id = item.DiscussionID }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 41 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                         if (@TempData["UT"].ToString() == "Teacher")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"linkDec\">");
#nullable restore
#line 43 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                                          Write(Html.ActionLink("Remove", "RemoveDiscussion", new { id = item.DiscussionID }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>      \r\n");
#nullable restore
#line 44 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n");
#nullable restore
#line 46 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>No Discussion have been created for this course.</p>\r\n");
#nullable restore
#line 51 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\Amber Kimberling\Source\Repos\Akimberling\VirtualClassroomDashboard\VirtualClassroomDashboard\Views\Home\Discussions.cshtml"
             
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VirtualClassroomDashboard.Models.DiscussionsModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
