#pragma checksum "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4604c46772bd1fc5b4cf399c137f2c8f478a356"
// <auto-generated/>
#pragma warning disable 1591
namespace TimeTracker.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using TimeTracker.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using TimeTracker.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using TimeTracker.Client.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\_Imports.razor"
using TimeTracker.Shared.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Login</h1>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
 if (ShowErrors)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "alert alert-danger");
            __builder.AddAttribute(4, "role", "alert");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "p");
            __builder.AddContent(7, 
#nullable restore
#line 10 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
            Error

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n");
#nullable restore
#line 12 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(10, "\r\n");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "card");
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "card-body");
            __builder.AddMarkupContent(16, "\r\n        ");
            __builder.AddMarkupContent(17, "<h5 class=\"card-title\">Please enter your details</h5>\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(18);
            __builder.AddAttribute(19, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 17 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
                         loginModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(20, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 17 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
                                                    HandleLogin

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(22, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(23);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(24, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(25);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(26, "\r\n\r\n            ");
                __builder2.OpenElement(27, "div");
                __builder2.AddAttribute(28, "class", "form-group");
                __builder2.AddMarkupContent(29, "\r\n                ");
                __builder2.AddMarkupContent(30, "<label for=\"email\">Email address</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(31);
                __builder2.AddAttribute(32, "Id", "email");
                __builder2.AddAttribute(33, "Class", "form-control");
                __builder2.AddAttribute(34, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
                                                                        loginModel.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(35, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => loginModel.Email = __value, loginModel.Email))));
                __builder2.AddAttribute(36, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => loginModel.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(37, "\r\n                ");
                __Blazor.TimeTracker.Client.Pages.Login.TypeInference.CreateValidationMessage_0(__builder2, 38, 39, 
#nullable restore
#line 24 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
                                          () => loginModel.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(40, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n            ");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "form-group");
                __builder2.AddMarkupContent(44, "\r\n                ");
                __builder2.AddMarkupContent(45, "<label for=\"password\">Password</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(46);
                __builder2.AddAttribute(47, "Id", "password");
                __builder2.AddAttribute(48, "type", "password");
                __builder2.AddAttribute(49, "Class", "form-control");
                __builder2.AddAttribute(50, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 28 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
                                                                                           loginModel.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(51, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => loginModel.Password = __value, loginModel.Password))));
                __builder2.AddAttribute(52, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => loginModel.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(53, "\r\n                ");
                __Blazor.TimeTracker.Client.Pages.Login.TypeInference.CreateValidationMessage_1(__builder2, 54, 55, 
#nullable restore
#line 29 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
                                          () => loginModel.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(56, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(57, "\r\n            ");
                __builder2.AddMarkupContent(58, "<button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(59, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "C:\Users\stewartlocke\Desktop\Software Project\TimeTracker\TimeTracker\TimeTracker\Client\Pages\Login.razor"
       

    private LoginModel loginModel = new LoginModel();
    private bool ShowErrors;
    private string Error = "";

    private async Task HandleLogin()
    {
        ShowErrors = false;

        var result = await AuthService.Login(loginModel);

        if (result.Successful)
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            Error = result.Error;
            ShowErrors = true;
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthService AuthService { get; set; }
    }
}
namespace __Blazor.TimeTracker.Client.Pages.Login
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
