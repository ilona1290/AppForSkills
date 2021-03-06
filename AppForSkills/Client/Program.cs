using Blazored.Modal;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MudBlazor;

namespace AppForSkills.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("oidc", options.ProviderOptions);
            });

            builder.Services.AddHttpClient("api", client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]))
                .AddHttpMessageHandler(sp =>
            {
                var handler = sp.GetService<AuthorizationMessageHandler>()
                .ConfigureHandler(
                    authorizedUrls: new[] { builder.Configuration["ApiUrl"] },
                    scopes: new[] { "api1" });
                return handler;
            });

            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));

            builder.Services.AddBlazoredModal();
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
                config.SnackbarConfiguration.VisibleStateDuration = 1000;
            });

            await builder.Build().RunAsync();
        }
    }
}
