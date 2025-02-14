using MongoDB.Bson;
using MongoDB.Driver;
using Simpoll.Blazor.Data.Models;

namespace Simpoll.Blazor.Repositories;

public class PollRepository : IPollRepository
{
    private readonly IMongoCollection<Poll> _polls;

    public PollRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("SimpollDb");
        _polls = database.GetCollection<Poll>("polls");
        
    }
    
    public async Task<ObjectId> Create(Poll poll)
    {
        await _polls.InsertOneAsync(poll);

        return poll.Id;
    }

    public async Task<Poll?> Get(ObjectId objectId)
    {
        var filter = Builders<Poll>.Filter.Eq(c => c.Id, objectId);
        return await _polls.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Poll>> GetAll()
    {
        return await _polls.Find(_ => true).ToListAsync();
    }
}