#pragma checksum "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f81c6c5fb9dcb98aca142f203d7d4c390a79661"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Job_Index), @"mvc.1.0.view", @"/Views/Job/Index.cshtml")]
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
#line 1 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
using JobSearchFullWebSite.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f81c6c5fb9dcb98aca142f203d7d4c390a79661", @"/Views/Job/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92a442ab32d93ed8d34b2538969960b6a47ba52e", @"/Views/_ViewImports.cshtml")]
    public class Views_Job_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JobIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ms-2 border-0 grey Width"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("p-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "job", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <main>\r\n        <div class=\"backColorBlue py-5\">\r\n            <div class=\"container\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f81c6c5fb9dcb98aca142f203d7d4c390a796615992", async() => {
                WriteLiteral(@"
                    <div class=""bg-white d-flex flex-row row g-4 p-4 border-radius""
                         style=""max-width: 100% !important"">
                        <div class=""
                  d-flex
                  flex-row
                   col-lg-3 col-md-6 col-12
                  align-items-center
                "">
                            <div class=""JobTitleIcon"">
                                <i class=""fas fa-search"" style=""font-size: 20px""></i>
                            </div>
                            <div>
                                <input type=""text""
                                       name=""search""
                                       class=""onclickBorderNone p-2 Width""
                                       placeholder=""Job Title..."" />
                            </div>
                        </div>
                        <div class=""
                  d-flex
                  flex-row
                  col-lg-3 col-md-6 col-12
          ");
                WriteLiteral(@"        align-items-center
                "">
                            <div class=""JobTitleIcon"">
                                <i class=""fas fa-map-marker-alt"" style=""font-size: 20px""></i>
                            </div>
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f81c6c5fb9dcb98aca142f203d7d4c390a796617598", async() => {
                    WriteLiteral("\r\n                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f81c6c5fb9dcb98aca142f203d7d4c390a796617898", async() => {
                        WriteLiteral("All Cities");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 38 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Job.City.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 38 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(Model.Cities,"Id","CityName"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </div>
                        <div class=""
                  d-flex
                  flex-row
                  col-lg-3 col-md-6 col-12
                  align-items-center
                "">
                            <div class=""JobTitleIcon"">
                                <i class=""fas fa-briefcase"" style=""font-size: 20px""></i>
                            </div>
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f81c6c5fb9dcb98aca142f203d7d4c390a7966111556", async() => {
                    WriteLiteral("\r\n                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f81c6c5fb9dcb98aca142f203d7d4c390a7966111857", async() => {
                        WriteLiteral("All Categories");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 51 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Job.JobCategory.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 51 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(Model.JobCategories,"Id","Name"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </div>
                        <div class=""
                  d-flex
                  flex-row
                  col-lg-3 col-md-6 col-12
                  blue
                  align-items-center
                "">
                            <div class=""JobTitleIcon"">
                                <i class=""fas fa-angle-down""></i>
                            </div>
                            <div class=""Advanced"">Advanced</div>
                            <div class=""ms-2"">
                                <button type=""submit"" class=""btn btn-primary"">
                                    Find Jobs
                                </button>
                            </div>
                        </div>
                    </div>
                    <div class=""
                bg-white
                border-radius
                flex-row
                row
                p-4
                me-2
                mt-2
                DropdownOnclic");
                WriteLiteral("kAdvanced\r\n              \">\r\n                        <div class=\"row\">\r\n                            <div class=\"col-lg-3 col-md-6 col-12 d-flex flex-column\">\r\n                                <b>Type</b>\r\n");
#nullable restore
#line 87 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                 foreach (var item in Model.JobType.GetType().GetEnumNames().ToList())
                                {
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""mt-3 d-flex flex-row"">
                                        <label class=""switch d-flex"">
                                            <input type=""checkbox"" />
                                            <span class=""slider round""></span>
                                        </label>
                                        <div class=""SwitchItem ms-2 grey"">");
#nullable restore
#line 95 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                                     Write(item);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                                    </div>\r\n");
#nullable restore
#line 97 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"

                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-lg-3 col-md-6 col-12 d-flex flex-column\">\r\n                                <b>Experience</b>\r\n");
#nullable restore
#line 103 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                 foreach (var item in Model.Experience.GetType().GetEnumNames().ToList())
	                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""mt-3 d-flex flex-row"">
                                        <label class=""switch d-flex"">
                                            <input type=""checkbox"" />
                                            <span class=""slider round""></span>
                                        </label>
                                        <div class=""SwitchItem ms-2 grey"">");
#nullable restore
#line 110 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                                     Write(item);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                                    </div>\r\n");
#nullable restore
#line 112 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
	                             }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                \r\n                            </div>\r\n                            <div class=\"col-lg-3 col-md-6 col-12 d-flex flex-column\">\r\n                                <b>Career Level</b>\r\n");
#nullable restore
#line 117 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                 foreach (var item in Model.CareerLevel.GetType().GetEnumNames().ToList())
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""mt-3 d-flex flex-row"">
                                        <label class=""switch d-flex"">
                                            <input type=""checkbox"" />
                                            <span class=""slider round""></span>
                                        </label>
                                        <div class=""SwitchItem ms-2 grey"">");
#nullable restore
#line 124 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                                     Write(item.ToString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                                    </div>\r\n");
#nullable restore
#line 126 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                            </div>\r\n                            <div class=\"col-lg-3 col-md-6 col-12 d-flex flex-column\">\r\n                                <b>Qualification</b>\r\n");
#nullable restore
#line 132 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                 foreach (var item in Model.Qualification.GetType().GetEnumNames())
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    <div class=""mt-3 d-flex flex-row"">
                                        <label class=""switch d-flex"">
                                            <input type=""checkbox"" />
                                            <span class=""slider round""></span>
                                        </label>
                                        <div class=""SwitchItem ms-2 grey"">");
#nullable restore
#line 139 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                                     Write(item);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                                    </div>\r\n");
#nullable restore
#line 141 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>

        <div class=""container"">
            <div class=""row my-5"">
                <div class=""col-md-6 col-12"">Showing All 18 Results</div>
                <div class=""col-md-6 col-12"">
                    <div class=""d-flex flex-row justify-content-end"">
                        <div class=""d-flex flex-column"">
                            <div class=""backColorBlue border-radius px-4 py-2 SortBy"">
                                Sort By >
                            </div>
                            <div class=""bg-white border-radius SortingBy p-3""
                                 style=""border: 1px solid grey"">
                                <div class=""d-flex flex-column"">
                                    <span>Newest</span>
                                    <span>Oldest</span>
                                    <span>Random</span>
                                </div>
                            </div>
                        </div>
       ");
            WriteLiteral(@"                 <div class=""d-flex flex-column ms-4"">
                            <div class=""backColorBlue border-radius px-4 py-2 AllClick"">
                                All >
                            </div>
                            <div class=""bg-white border-radius All p-3""
                                 style=""border: 1px solid grey"">
                                <div class=""d-flex flex-column"">
                                    <span>12 Per page</span>
                                    <span>All</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""mx-4"">
            <div class=""row my-5 g-4"">
");
#nullable restore
#line 186 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                 foreach (var item in Model.Jobs)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-md-6 col-12"">
                        <div class=""card p-2 border-radius JobListCardShadow py-4"">
                            <div class=""container flex-row JobListCard"">
                                <div class=""JobListCardImage"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9f81c6c5fb9dcb98aca142f203d7d4c390a7966126650", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 9277, "~/SiteImages/", 9277, 13, true);
#nullable restore
#line 192 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
AddHtmlAttributeValue("", 9290, item.JobImages.FirstOrDefault(x=>x.IsPoster).Image, 9290, 51, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                                <div class=""row ms-2"">
                                    <div class=""row"">
                                        <div class=""col-sm-10 col-12 d-flex flex-row"">
                                            <div class=""row"">
                                                <div class=""col-lg-8 col-12"">
                                                    <h5><b>");
#nullable restore
#line 200 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                      Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h5>\r\n                                                </div>\r\n");
#nullable restore
#line 202 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                 if (item.IsFeatured)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"col-lg-4 col-12\">\r\n                                                        <span class=\"green\">Featured</span>\r\n                                                    </div>\r\n");
#nullable restore
#line 207 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </div>
                                        </div>
                                        <div class=""col-sm-2 col-12 d-flex flex-row"">
                                            <i class=""far fa-bookmark""></i>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""
                        col-lg-4 col-md-6 col-12
                        d-flex
                        flex-row
                        justify-content-center
                        align-items-center
                        grey
                      "">
                                            <i class=""fas fa-briefcase me-2""></i>
                                            <span>");
#nullable restore
#line 225 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                             Write(item.JobCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                        </div>
                                        <div class=""
                        col-lg-4 col-md-6 col-12
                        d-flex
                        flex-row
                        justify-content-center
                        align-items-center
                        grey
                      "">
                                            <i class=""fas fa-map-marker-alt me-2""></i>
                                            <span>");
#nullable restore
#line 236 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                             Write(item.City.CityName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                        </div>
                                        <div class=""
                        col-lg-4 col-md-6 col-12
                        d-flex
                        flex-row
                        justify-content-center
                        align-items-center
                        grey
                      "">
                                            <i class=""far fa-money-bill-alt me-2""></i>
                                            <span>");
#nullable restore
#line 247 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                             Write(item.OfferedMinSalary);

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 247 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                                    Write(item.OfferedMaxSalary);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 247 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                                                           Write(item.OfferedSalaryForTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                        </div>
                                    </div>
                                    <div class=""row"">
                                        <div class=""col-md-4 col-12"">
                                            <div class=""
                          border-radius
                          px-2
                          d-flex
                          align-items-center
                          justify-content-center
                        ""
                                                 style=""background-color: #dde8f8; color: #1967d2"">
                                                <span>");
#nullable restore
#line 260 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                                 Write(item.JobType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </div>\r\n                                        </div>\r\n                                        <div class=\"col-md-4 col-12\">\r\n");
#nullable restore
#line 264 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                             if (item.IsUrgent)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <div class=""
                          border-radius
                          px-2
                          d-flex
                          align-items-center
                          justify-content-center
                        ""
                                                     style=""background-color: #fef2d9; color: #fbbb00"">
                                                    <span>Urgent</span>
                                                </div>
");
#nullable restore
#line 276 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 283 "C:\Users\elman\Desktop\JobSearch\JobSearchFullWebSite\JobSearchFullWebSite\Views\Job\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </main>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JobIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
