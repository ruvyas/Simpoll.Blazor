using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace Simpoll.Blazor.Data.Models;

public class Poll
{
    public ObjectId Id { get; init; }
    
    [Required(ErrorMessage = "Please enter the name of the poll")]
    [MaxLength(4056)]
    public required string Question { get; init; }
    
    public DateTime CreatedAt => DateTime.UtcNow;
    public DateTime LastUpdatedAt => DateTime.UtcNow;
    
    [Required(ErrorMessage = "Please enter poll options")]
    public required List<PollOption> Options { get; init; }
}

public class PollOption
{
    public ObjectId OptionId { get; set; }
    
    [Required(ErrorMessage = "Please enter the name of the option")]
    [MaxLength(4056)]
    public required string OptionText { get; init; }
    
    public int VoteCount { get; set; }
}