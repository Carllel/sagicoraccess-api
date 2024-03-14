using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sagicor.Access.Api.AdminUI;
using Sagicor.Access.Api.AdminUI.Contracts;
using Sagicor.Access.Api.AdminUI.Services;
using Sagicor.Access.Api.AdminUI.Services.Base;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Microsoft.Extensions.Http
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri
    ("https://localhost:7163"));

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IPLCategoryService, PLCategoryService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
