using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services;

public class ActorService : IDataHelper<Actor>
{
    private readonly AppDbContext context;
    public ActorService(AppDbContext appDbContext)
    {
        context = appDbContext;
    }

    public void Update(Actor actor)
    {
        try
        {
            context.Actors.Update(actor);
            context.SaveChanges();
        }catch { }
    }

    public void Add(Actor actor)
    {
        try
        {
            context.Actors.Add(actor);
            context.SaveChanges();

        }
        catch { }
    }

    public void Delete(int id)
    {
        try
        {
            var actor = context.Actors.First(x => x.ActorId == id);
            context.Actors.Remove(actor);
            context.SaveChanges();
        }
        catch { }
    }

    public async Task<IEnumerable<Actor>> GetAll()
    {
        return await context.Actors.ToListAsync();
    }

    public Actor GetById(int id)
    {
        try
        {
            return context.Actors.FirstOrDefault(x => x.ActorId == id);

        }
        catch { return new Actor(); }
    }
}
