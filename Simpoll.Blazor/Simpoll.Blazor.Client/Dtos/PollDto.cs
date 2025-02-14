namespace Simpoll.Blazor.Client.Dtos;

public record PollDto
{
    public string? Id { get; set; }
    public string? Question { get; set; }
    public IEnumerable<PollOptionDto>? Options { get; set; }
}

public record PollOptionDto
{
    public string? OptionText { get; init; }
    
    public int VoteCount { get; set; }
}