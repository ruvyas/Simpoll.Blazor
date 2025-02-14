using Simpoll.Blazor.Client.Dtos;
using Simpoll.Blazor.Data.Models;

namespace Simpoll.Blazor.Extensions;

public static class PollExtension
{
    public static PollDto ToPollDto(this Poll poll)
        => new()
        {
            Question = poll.Question,
            Options = poll.Options.Select(x => x.ToPollOptionDto())
        };

    private static PollOptionDto ToPollOptionDto(this PollOption pollOption)
        => new()
        {
            OptionText = pollOption.OptionText,
            VoteCount = pollOption.VoteCount
        };
}