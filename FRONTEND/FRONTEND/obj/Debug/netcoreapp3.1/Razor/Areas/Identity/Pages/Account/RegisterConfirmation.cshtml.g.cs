#pragma checksum "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "280bacb04c6ee9d44ff316a58799637852c8d48c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_RegisterConfirmation), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml")]
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
#line 1 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\_ViewImports.cshtml"
using FRONTEND.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\_ViewImports.cshtml"
using FRONTEND.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using FRONTEND.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"280bacb04c6ee9d44ff316a58799637852c8d48c", @"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d697ce2d218cd7e4bc7dcde143b2840ddd49cb42", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac3676958db25cd084e3cb4a888ccacd0ca156eb", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_RegisterConfirmation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
  
    ViewData["Title"] = "Confirmación de registro";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>");
#nullable restore
#line 7 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n");
#nullable restore
#line 8 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
  
    if (@Model.DisplayConfirmAccountLink)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\n    This app does not currently have a real email sender registered, see <a href=\"https://aka.ms/aspaccountconf\">these docs</a> for how to configure a real email sender.\n    Normally this would be emailed: <a id=\"confirm-link\"");
            BeginWriteAttribute("href", " href=\"", 406, "\"", 440, 1);
#nullable restore
#line 13 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
WriteAttributeValue("", 413, Model.EmailConfirmationUrl, 413, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Haga clic aquí para confirmar su cuenta</a>\n</p>\n");
#nullable restore
#line 15 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\n        Por favor revise su email para confirmar su cuenta.\n</p>\n");
#nullable restore
#line 21 "C:\Users\Joan\source\repos\JoanJuan10\.NET_PROJECT\FRONTEND\FRONTEND\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegisterConfirmationModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RegisterConfirmationModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RegisterConfirmationModel>)PageContext?.ViewData;
        public RegisterConfirmationModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
