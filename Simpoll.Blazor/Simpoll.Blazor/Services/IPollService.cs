using MongoDB.Bson;
using Simpoll.Blazor.Data.Models;

namespace Simpoll.Blazor.Services;

public interface IPollService
{
    IEnumerable<Poll> GetPolls();
    
    Poll? GetPollById(ObjectId id);
    
    void AddPoll(Poll poll);
    void EditPoll(Poll poll);
    void DeletePoll(Poll poll);
}