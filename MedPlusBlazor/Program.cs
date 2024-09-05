using MedPlusBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var umbracoBaseAddress = builder.Configuration["UmbracoBaseAddress"];
if (string.IsNullOrEmpty(umbracoBaseAddress))
{
    throw new InvalidOperationException("Umbraco base address is not configured.");
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(umbracoBaseAddress) });


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
