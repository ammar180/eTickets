using eTickets.Models;

namespace eTickets.Data.Services;

public interface IDataHelper<Entity>
{
    Task<IEnumerable<Entity>> GetAll();
    void Add(Entity entity);
    Entity GetById(int id);
    void Update(Entity entity);
    void Delete(int id);
}
