using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace Simpoll.Blazor.Data.Models;

[Collection("polls")]
public class Poll
{
    public ObjectId Id { get; init; }
    
    [Required(ErrorMessage = "Please enter the name of the poll")]
    [MaxLength(4056)]
    public required string Question { get; set; }
    
    public DateTime CreatedAt { get; init; }
    public DateTime LastUpdatedAt { get; init; }
    
    [Required(ErrorMessage = "Please enter poll options")]
    public required List<PollOption> Options { get; set; }
}

public class PollOption
{
    public ObjectId OptionId { get; set; }
    
    [Required(ErrorMessage = "Please enter the name of the option")]
    [MaxLength(4056)]
    public required string OptionText { get; set; }
    
    public int VoteCount { get; set; }
}