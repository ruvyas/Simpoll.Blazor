using MongoDB.Bson;
using Simpoll.Blazor.Data.Models;

namespace Simpoll.Blazor.Repositories;

public interface IPollRepository
{
    Task<ObjectId> Create(Poll poll);
    
    Task<Poll?> Get(ObjectId objectId);
    Task<IEnumerable<Poll>> GetAll();
    
}