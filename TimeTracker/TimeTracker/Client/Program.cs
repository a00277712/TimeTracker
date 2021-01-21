using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TimeTracker.Client.Services;

namespace TimeTracker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("TimeTracker.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TimeTracker.ServerAPI"));

            builder.Services.AddApiAuthorization()
                .AddAccountClaimsPrincipalFactory<RolesClaimsPrincipalFactory>();

            builder.Services.AddTransient<ISetupUserService, SetupUsersService>();
            builder.Services.AddTransient<IProjectService, ProjectService>();
            builder.Services.AddTransient<ITaskService, TaskService>();
            builder.Services.AddTransient<ITimeService, TimeService>();
            builder.Services.AddTransient<IBillableTypeService, BillableTypesService>();
            builder.Services.AddTransient<IValidateUser, ValidateUser>();
            builder.Services.AddTransient<IValidateProject, ValidateProject>();

            await builder.Build().RunAsync();
        }
    }
}
