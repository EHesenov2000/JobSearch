#pragma checksum "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Candidate\CandidateApplieds.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae77d2ced782ded2ec2c0e7bd1d80f8876470c5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Candidate_CandidateApplieds), @"mvc.1.0.view", @"/Views/Candidate/CandidateApplieds.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae77d2ced782ded2ec2c0e7bd1d80f8876470c5a", @"/Views/Candidate/CandidateApplieds.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92a442ab32d93ed8d34b2538969960b6a47ba52e", @"/Views/_ViewImports.cshtml")]
    public class Views_Candidate_CandidateApplieds : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Candidate\CandidateApplieds.cshtml"
  
    ViewData["Title"] = "CandidateApplieds";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    
    <div class=""cont"">
        <div class=""main px-4"">


                            <br />
                            <br />
                            <h4><b>Applied Jobs</b></h4>
                            <div class=""card p-4"">
                                <div class=""d-flex flex-row"">
                                    <div class=""
                    SearchIcon
                    d-flex
                    flex-row
                    backColorBlue
                    border-radius
                    py-2
                    px-2
                  "">
                                        <i class=""fas fa-search d-flex flex-row align-items-center""></i>
                                        <input type=""text""
                                               placeholder=""Search""
                                               class=""border-0 backColorBlue border-radius"" />
                                    </div>
                                </div>
           ");
            WriteLiteral(@"                     <div class=""table-responsive mt-4"">
                                    <table class=""table"">
                                        <thead>
                                            <tr class=""bg-primary"">
                                                <th scope=""col"" class=""fontSize14"">Job Title</th>
                                                <th scope=""col"" class=""fontSize14"">Data Applied</th>
                                                <th scope=""col"" class=""fontSize14"">Status</th>
                                                <th scope=""col"" class=""fontSize14"">Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr");
            BeginWriteAttribute("class", " class=\"", 1905, "\"", 1913, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <td class=""fontSize14"">
                                                    <div class=""d-flex flex-row"">
                                                        <div>
                                                            <img style=""max-width: 50px; height: auto""
                                                                 src=""./../SiteImages/y12.jpg""");
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 2334, "\"", 2406, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                                        </div>
                                                        <div class=""
                              d-flex
                              flex-column
                              justify-content-center
                              ms-3
                            "">
                                                            <div><b>Restaurant Team Member</b></div>
                                                            <div class=""d-flex flex-row"">
                                                                <div class=""d-flex flex-row grey align-items-center"">
                                                                    <i class=""fas fa-briefcase""></i><span class=""ms-1"">Customer</span>
                                                                </div>
                                                                <div class=""
                                  d-flex
                                  flex-row");
            WriteLiteral(@"
                                  grey
                                  align-items-center
                                  ms-2
                                "">
                                                                    <i class=""fas fa-map-marker-alt""></i>
                                                                    <span class=""ms-1"">New York</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    May 7, 2021
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: midd");
            WriteLiteral(@"le"">
                                                    Approved
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    <div class=""d-flex flex-row"">
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 5450, "\"", 5457, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                                <i class=""fas fa-times blue""></i>
                                                            </a>
                                                        </div>
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              ms-2
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 6411, "\"", 6418, 0);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fas fa-eye blue""></i></a>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr");
            BeginWriteAttribute("class", " class=\"", 6734, "\"", 6742, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <td class=""fontSize14"">
                                                    <div class=""d-flex flex-row"">
                                                        <div>
                                                            <img style=""max-width: 50px; height: auto""
                                                                 src=""./../SiteImages/y12.jpg""");
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 7163, "\"", 7235, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                                        </div>
                                                        <div class=""
                              d-flex
                              flex-column
                              justify-content-center
                              ms-3
                            "">
                                                            <div><b>Restaurant Team Member</b></div>
                                                            <div class=""d-flex flex-row"">
                                                                <div class=""d-flex flex-row grey align-items-center"">
                                                                    <i class=""fas fa-briefcase""></i><span class=""ms-1"">Customer</span>
                                                                </div>
                                                                <div class=""
                                  d-flex
                                  flex-row");
            WriteLiteral(@"
                                  grey
                                  align-items-center
                                  ms-2
                                "">
                                                                    <i class=""fas fa-map-marker-alt""></i>
                                                                    <span class=""ms-1"">New York</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    May 7, 2021
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: midd");
            WriteLiteral(@"le"">
                                                    Approved
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    <div class=""d-flex flex-row"">
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 10279, "\"", 10286, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                                <i class=""fas fa-times blue""></i>
                                                            </a>
                                                        </div>
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              ms-2
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 11240, "\"", 11247, 0);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fas fa-eye blue""></i></a>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr");
            BeginWriteAttribute("class", " class=\"", 11563, "\"", 11571, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <td class=""fontSize14"">
                                                    <div class=""d-flex flex-row"">
                                                        <div>
                                                            <img style=""max-width: 50px; height: auto""
                                                                 src=""./../SiteImages/y12.jpg""");
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 11992, "\"", 12064, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                                        </div>
                                                        <div class=""
                              d-flex
                              flex-column
                              justify-content-center
                              ms-3
                            "">
                                                            <div><b>Restaurant Team Member</b></div>
                                                            <div class=""d-flex flex-row"">
                                                                <div class=""d-flex flex-row grey align-items-center"">
                                                                    <i class=""fas fa-briefcase""></i><span class=""ms-1"">Customer</span>
                                                                </div>
                                                                <div class=""
                                  d-flex
                                  flex-row");
            WriteLiteral(@"
                                  grey
                                  align-items-center
                                  ms-2
                                "">
                                                                    <i class=""fas fa-map-marker-alt""></i>
                                                                    <span class=""ms-1"">New York</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    May 7, 2021
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: midd");
            WriteLiteral(@"le"">
                                                    Approved
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    <div class=""d-flex flex-row"">
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 15108, "\"", 15115, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                                <i class=""fas fa-times blue""></i>
                                                            </a>
                                                        </div>
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              ms-2
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 16069, "\"", 16076, 0);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fas fa-eye blue""></i></a>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr");
            BeginWriteAttribute("class", " class=\"", 16392, "\"", 16400, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <td class=""fontSize14"">
                                                    <div class=""d-flex flex-row"">
                                                        <div>
                                                            <img style=""max-width: 50px; height: auto""
                                                                 src=""./../SiteImages/y12.jpg""");
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 16821, "\"", 16893, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                                        </div>
                                                        <div class=""
                              d-flex
                              flex-column
                              justify-content-center
                              ms-3
                            "">
                                                            <div><b>Restaurant Team Member</b></div>
                                                            <div class=""d-flex flex-row"">
                                                                <div class=""d-flex flex-row grey align-items-center"">
                                                                    <i class=""fas fa-briefcase""></i><span class=""ms-1"">Customer</span>
                                                                </div>
                                                                <div class=""
                                  d-flex
                                  flex-row");
            WriteLiteral(@"
                                  grey
                                  align-items-center
                                  ms-2
                                "">
                                                                    <i class=""fas fa-map-marker-alt""></i>
                                                                    <span class=""ms-1"">New York</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    May 7, 2021
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: midd");
            WriteLiteral(@"le"">
                                                    Approved
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    <div class=""d-flex flex-row"">
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 19937, "\"", 19944, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                                <i class=""fas fa-times blue""></i>
                                                            </a>
                                                        </div>
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              ms-2
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 20898, "\"", 20905, 0);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fas fa-eye blue""></i></a>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr");
            BeginWriteAttribute("class", " class=\"", 21221, "\"", 21229, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                <td class=""fontSize14"">
                                                    <div class=""d-flex flex-row"">
                                                        <div>
                                                            <img style=""max-width: 50px; height: auto""
                                                                 src=""./../SiteImages/y12.jpg""");
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 21650, "\"", 21722, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                                        </div>
                                                        <div class=""
                              d-flex
                              flex-column
                              justify-content-center
                              ms-3
                            "">
                                                            <div><b>Restaurant Team Member</b></div>
                                                            <div class=""d-flex flex-row"">
                                                                <div class=""d-flex flex-row grey align-items-center"">
                                                                    <i class=""fas fa-briefcase""></i><span class=""ms-1"">Customer</span>
                                                                </div>
                                                                <div class=""
                                  d-flex
                                  flex-row");
            WriteLiteral(@"
                                  grey
                                  align-items-center
                                  ms-2
                                "">
                                                                    <i class=""fas fa-map-marker-alt""></i>
                                                                    <span class=""ms-1"">New York</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    May 7, 2021
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: midd");
            WriteLiteral(@"le"">
                                                    Approved
                                                </td>
                                                <td class=""fontSize14"" style=""vertical-align: middle"">
                                                    <div class=""d-flex flex-row"">
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 24766, "\"", 24773, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                                <i class=""fas fa-times blue""></i>
                                                            </a>
                                                        </div>
                                                        <div style=""
                              background-color: #eff4fc;
                              width: 30px;
                              height: 30px;
                            ""
                                                             class=""
                              d-flex
                              flex-row
                              align-items-center
                              justify-content-center
                              border-radius
                              ms-2
                              AplliedJobIcon
                            "">
                                                            <a");
            BeginWriteAttribute("href", " href=\"", 25727, "\"", 25734, 0);
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fas fa-eye blue""></i></a>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
        </div>
        <div class=""sidebar ps-3"">
            <div");
            BeginWriteAttribute("class", " class=\"", 26243, "\"", 26251, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"ImageAndUserName flex-row\">\r\n                    <div class=\"UserImage d-flex align-items-center\">\r\n                        <img src=\"./../SiteImages/member4.jpg\"");
            BeginWriteAttribute("alt", "\r\n                             alt=\"", 26445, "\"", 26481, 0);
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
            BeginWriteAttribute("href", " href=\"", 27046, "\"", 27053, 0);
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
                        <div class=""Icon""><i class=""fas fa-file-sign");
            WriteLiteral(@"ature""></i></div>
                        <div class=""SectionName ms-2"">My resume</div>
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
                        <div class=""Icon""");
            WriteLiteral(@"><i class=""fas fa-volume-up""></i></div>
                        <div class=""SectionName ms-2"">Alert Jobs</div>
                    </a>
                    <a class=""d-flex mt-2 UserProfileItem px-2 border-radius"">
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
                        <d");
            WriteLiteral(@"iv class=""Icon""><i class=""fas fa-power-off""></i></div>
                        <div class=""SectionName ms-2"">Logout</div>
                    </a>
                </div>
            </div>
        </div>
    </div>

    <style>
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
    </style>");
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