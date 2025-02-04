using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Simpoll.Blazor.Data;
using Simpoll.Blazor.Data.Models;

namespace Simpoll.Blazor.Services;

public class PollService(PollContext pollContext) : IPollService
{
    public IEnumerable<Poll> GetPolls()
    {
        return pollContext.Polls.OrderBy(c => c.Id).AsNoTracking().AsEnumerable();
    }

    public Poll? GetPollById(ObjectId id)
    {
        return pollContext.Polls.FirstOrDefault(c  => c.Id == id);
    }

    public void AddPoll(Poll poll)
    {
        pollContext.Polls.Add(poll);
        pollContext.ChangeTracker.DetectChanges();
        Console.WriteLine(pollContext.ChangeTracker.DebugView.LongView);
        pollContext.SaveChanges();
    }

    public void EditPoll(Poll poll)
    {
        throw new NotImplementedException();
    }

    public void DeletePoll(Poll poll)
    {
        throw new NotImplementedException();
    }
}