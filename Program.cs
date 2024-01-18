using BlazorServerSyncfusion.Components;
using BlazorServerSyncfusion.Interfaces;
using BlazorServerSyncfusion.Models;
using BlazorServerSyncfusion.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<TdmsFilesContext>();
builder.Services.AddScoped<IDatabase<TdmsFile>, TdmsFileService>();
builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA0NjUzN0AzMjM0MmUzMDJlMzBnS05HTzR6SGVlVUtMQlVrRzNQZFRqZGJFV0ZWZDFIMHkrVU5GdWVvVlk0PQ=="); //라이센스 추가

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
