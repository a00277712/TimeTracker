using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TimeTracker.Client.HttpInterceptor;
using TimeTracker.Client.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace TimeTracker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("TimeTracker.ServerAPI", (sp, client) => {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                    client.EnableIntercept(sp);
                })
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TimeTracker.ServerAPI"));

            builder.Services.AddHttpClientInterceptor();

            builder.Services.AddApiAuthorization()
                .AddAccountClaimsPrincipalFactory<RolesClaimsPrincipalFactory>();

            builder.Services.AddScoped<ISetupUserService, SetupUsersService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITimeService, TimeService>();
            builder.Services.AddScoped<IBillableTypeService, BillableTypesService>();
            builder.Services.AddScoped<IValidateUser, ValidateUser>();
            builder.Services.AddScoped<IValidateProject, ValidateProject>();
            builder.Services.AddScoped<IProjectCloseoutService, ProjectCloseoutService>();
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<HttpInterceptorService>();

            await builder.Build().RunAsync();
        }
    }
}
