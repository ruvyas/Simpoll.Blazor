using Simpoll.Blazor.Client.Dtos;
using Simpoll.Blazor.Client.Interfaces;

namespace Simpoll.Blazor.Endpoints;

public static class PollEndpoints
{
    public static IEndpointRouteBuilder MapPollEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/polls",
            async (PollDto request, IPollService pollService, CancellationToken cancellationToken) =>
            {
                var newPollId = await pollService.CreatePollAsync(request);
                return Results.Created($"/api/polls/{newPollId}", newPollId);
            });
        return app;
    }
}