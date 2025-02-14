using Simpoll.Blazor.Client.Dtos;
using Simpoll.Blazor.Client.Interfaces;

namespace Simpoll.Blazor.Client.Services;

public class PollApiProxy(IPollApi pollApi) : IPollService
{
    public Task<string> CreatePollAsync(PollDto poll)
        => pollApi.CreatePollAsync(poll);

    public Task<PollDto> GetPollById(string objectId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PollDto>> GetAllPolls()
    {
        throw new NotImplementedException();
    }
}