using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShelfSync.Shared.Services;
using ShelfSync.Shared.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore(); 

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<ICategoryService, ClientCategoryService>();
builder.Services.AddScoped<IBinService, ClientBinsService>();
builder.Services.AddScoped<IBinItemService, ClientBinItemService>();


await builder.Build().RunAsync();
