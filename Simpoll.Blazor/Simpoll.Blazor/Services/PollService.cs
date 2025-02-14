using MongoDB.Bson;
using Simpoll.Blazor.Client.Dtos;
using Simpoll.Blazor.Client.Interfaces;
using Simpoll.Blazor.Data.Models;
using Simpoll.Blazor.Extensions;
using Simpoll.Blazor.Repositories;

namespace Simpoll.Blazor.Services;

public class PollService(IPollRepository pollRepository) : IPollService
{
    public async Task<string> CreatePollAsync(PollDto poll)
    {
        Poll pollEntity = new()
        {
            Question = poll.Question ?? throw new InvalidOperationException(),
            Options = (poll.Options ?? throw new InvalidOperationException()).Select(x => new PollOption
            {
                OptionText = x.OptionText ?? throw new InvalidOperationException()
            }).ToList()
        };
        return (await pollRepository.Create(pollEntity)).ToString();
    }

    public async Task<PollDto> GetPollById(string objectId)
    {
        PollDto dto = new();
        var poll = await pollRepository.Get(ObjectId.Parse(objectId));
        return poll is null ? dto : poll.ToPollDto();
    }

    public async Task<IEnumerable<PollDto>> GetAllPolls()
        => (await pollRepository.GetAll()).Select(x => x.ToPollDto());
}