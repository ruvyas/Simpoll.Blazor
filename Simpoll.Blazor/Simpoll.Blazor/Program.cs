using MongoDB.Driver;
using Simpoll.Blazor.Client.Interfaces;
using Simpoll.Blazor.Components;
using Simpoll.Blazor.Endpoints;
using Simpoll.Blazor.Repositories;
using Simpoll.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add mongoDb
builder.Services.AddSingleton<IMongoClient, MongoClient>(_ 
    => new MongoClient(builder.Configuration.GetConnectionString("MongoDb") ?? "")
);

builder.Services.AddScoped<IPollRepository, PollRepository>();
builder.Services.AddScoped<IPollService, PollService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Simpoll.Blazor.Client._Imports).Assembly);

app.MapPollEndpoints();

app.Run();