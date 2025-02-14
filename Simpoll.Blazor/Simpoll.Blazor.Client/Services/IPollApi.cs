using Refit;
using Simpoll.Blazor.Client.Dtos;

namespace Simpoll.Blazor.Client.Services;

public interface IPollApi
{
    [Post("/api/polls")]
    Task<string> CreatePollAsync(PollDto poll);
}