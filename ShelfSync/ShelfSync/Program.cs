using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShelfSync.Client.Pages;
using ShelfSync.Components;
using ShelfSync.Data;
using ShelfSync.Services;
using ShelfSync.Shared.Services;
using ShelfSync.Shared.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

// DB CONTEXT
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// add IDENTITY 
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddRazorPages();

// SCOPE
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBinService, BinsService>();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value),
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

// ENDPOINTS
app.MapControllers();
app.MapRazorPages(); 
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ShelfSync.Client._Imports).Assembly);

app.Run();