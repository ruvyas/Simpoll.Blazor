using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using Simpoll.Blazor.Client.Interfaces;
using Simpoll.Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddRefitClient<IPollApi>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    });
builder.Services.AddScoped<IPollService, PollApiProxy>();


await builder.Build().RunAsync();