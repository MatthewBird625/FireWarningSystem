using FireWarningSystem.UiLogic.Services;
using FireWarningSystem.UiLogic.ViewModels;
using FireWarningSystem.UiLogic.ViewModels.Implementation;
using FireWarningSystem.Web.Components;
using MudBlazor;
using MudBlazor.Services;
using WarningClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWarningClient(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

//register transients

builder.Services
    .AddTransient<ISnackbarService, FireWarningSystem.UiLogic.Services.Implementation.SnackbarService>()
    .AddTransient<IFireWarningViewModel, FireWarningViewModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
