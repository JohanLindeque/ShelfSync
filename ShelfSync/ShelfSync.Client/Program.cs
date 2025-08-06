using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShelfSync.Shared.Services;
using ShelfSync.Shared.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<ICategoryService, ClientCategoryService>();
builder.Services.AddScoped<IBinService, ClientBinsService>();


await builder.Build().RunAsync();
