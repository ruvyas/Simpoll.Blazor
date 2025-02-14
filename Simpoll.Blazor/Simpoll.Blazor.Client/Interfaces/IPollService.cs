using Simpoll.Blazor.Client.Dtos;

namespace Simpoll.Blazor.Client.Interfaces;

public interface IPollService
{
    Task<string> CreatePollAsync(PollDto poll);
    Task<PollDto> GetPollById(string objectId);
    Task<IEnumerable<PollDto>> GetAllPolls();
}