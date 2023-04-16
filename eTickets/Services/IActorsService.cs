using eTickets.Models;

namespace eTickets.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetById(int id);
        Task Add(Actor actor);
        Task<Actor> Update(int id, Actor newActor);
        Task Delete(int id);
    }
}
