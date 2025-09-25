using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using NuGetTrends.Portal;
using NuGetTrends.Portal.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://nugettrends.com") });
builder.Services.AddScoped<IUserInterfaceService, UserInterfaceService>();
builder.Services.AddTransient<INugetTrendsWebService, FakeNugetTrendsWebService>();

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
