#pragma checksum "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c3129fc937e71fd20df7f1a341db65870eb9391"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employer_GetFollowers), @"mvc.1.0.view", @"/Views/Employer/GetFollowers.cshtml")]
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
#line 1 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\_ViewImports.cshtml"
using JobSearchFullWebSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml"
using JobSearchFullWebSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c3129fc937e71fd20df7f1a341db65870eb9391", @"/Views/Employer/GetFollowers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92a442ab32d93ed8d34b2538969960b6a47ba52e", @"/Views/_ViewImports.cshtml")]
    public class Views_Employer_GetFollowers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Follower>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "getfollowers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "employer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml"
  
    ViewData["Title"] = "GetFollowers";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml"
  
    int totalPage = (int)ViewBag.TotalPageCount;
    int selectedPage = (int)ViewBag.SelectedPage;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"cont\">\r\n    <div class=\"main px-4\">\r\n        <div class=\"row gx-4 gy-4\" >\r\n");
#nullable restore
#line 14 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4\">\r\n                    <div class=\"card d-flex flex-row  py-2\">\r\n                        <div class=\"col-md-10 d-flex flex-row align-items-center\">\r\n                            <div class=\"Image\"><img");
            BeginWriteAttribute("src", " src=\"", 650, "\"", 723, 1);
#nullable restore
#line 19 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml"
WriteAttributeValue("", 656, item.Candidate.CandidateImages.FirstOrDefault(x=>x.IsPoster).Image, 656, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Sekil yuklenmedi\" style=\"width:50px;height:50px;border-radius:50%;\" /></div>\r\n                            <div class=\"Name ms-2\">");
#nullable restore
#line 20 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml"
                                              Write(item.Candidate.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                        </div>
                        <div class=""col-md-2 d-flex flex-row align-items-center justify-content-end"" >
                            <a class=""??con backColorBlue d-flex justify-content-center align-items-center"" style=""border-radius:50%;width:20px;height:20px;""><i class=""fas fa-times p-1""></i></a>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 27 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    <br />\r\n        <div class=\"d-flex justify-content-center w-100\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c3129fc937e71fd20df7f1a341db65870eb93916652", async() => {
                WriteLiteral("<button class=\"btn btn-primary px-4\">Load More Listing</button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Employer\GetFollowers.cshtml"
                                                                        WriteLiteral(selectedPage<totalPage?selectedPage+1:totalPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"sidebar ps-3\">\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 1688, "\"", 1696, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"ImageAndUserName flex-row\">\r\n                <div class=\"UserImage d-flex align-items-center\">\r\n                    <img src=\"./../SiteImages/member4.jpg\"");
            BeginWriteAttribute("alt", "\r\n                         alt=\"", 1878, "\"", 1910, 0);
            EndWriteAttribute();
            WriteLiteral(@"
                         style=""width: 60px; height: 60px; border-radius: 50%"" />
                </div>
                <div class=""
                    d-flex
                    flex-column
                    ms-3
                    align-items-center
                    justify-content-center
                  "">
                    <div class=""UserName""><b>User Name</b></div>
                    <div class=""UserCity"">User City</div>
                    <div class=""UserProfileButton"">
                        <a");
            BeginWriteAttribute("href", " href=\"", 2447, "\"", 2454, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <button class=""btn btn-primary"" style=""font-size: 10px"">
                                View Profile
                            </button>
                        </a>
                    </div>
                </div>
            </div>
            <div class=""d-flex flex-column"">
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""far fa-file-alt""></i></div>
                    <div class=""SectionName ms-2"">User Dashboard</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""far fa-user-circle""></i></div>
                    <div class=""SectionName ms-2"">Profile</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""fas fa-file-signature""></i></div>
                    <div class=""SectionName ms-2"">My ");
            WriteLiteral(@"resume</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""fas fa-volume-up""></i></div>
                    <div class=""SectionName ms-2"">My applied</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""far fa-bookmark""></i></div>
                    <div class=""SectionName ms-2"">Shortlist Jobs</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""far fa-user""></i></div>
                    <div class=""SectionName ms-2"">Following Employers</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""fas fa-volume-up""></i></div>
                    <div class=""SectionName ms-2"">Alert Jobs</div>
                </a>
     ");
            WriteLiteral(@"           <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""fab fa-weixin""></i></div>
                    <div class=""SectionName ms-2"">Messages</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""fas fa-lock""></i></div>
                    <div class=""SectionName ms-2"">Change Password</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""far fa-trash-alt""></i></div>
                    <div class=""SectionName ms-2"">Delete Profile</div>
                </a>
                <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
                    <div class=""Icon""><i class=""fas fa-power-off""></i></div>
                    <div class=""SectionName ms-2"">Logout</div>
                </a>
            </div>
        </div>
    </div>
    </div>");
            WriteLiteral(@"

<style>
    .??con:hover {
        background-color: blue;
        transition-duration: 0.3s;
    }
    .??con:hover i {
      color: white !important;
    }
    .??con {
        transition-duration: 0.3s;
    }

    body {
        font-size: 15px !important;
    }

    .sidebar {
        background: black;
        color: white;
        position: fixed;
        width: 20%;
        height: 100%;
        left: 0;
        overflow: auto;
        display: block;
        margin-top: -30px !important;
        padding-top: 40px !important;
    }

    .main {
        background: silver;
        color: black;
        width: 80%;
        float: right;
    }

        .main p {
            margin-bottom: 50px;
        }

    footer {
        display: none;
    }

    .ImageAndUserName {
        display: flex;
    }
</style>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Follower>> Html { get; private set; }
    }
}
#pragma warning restore 1591
