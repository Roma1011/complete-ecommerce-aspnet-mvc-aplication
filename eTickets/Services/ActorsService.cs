using eTickets.Data;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services
{
    public class ActorsService:IActorsService
    {
        private readonly AppDbContext _appDbContext;
        public ActorsService(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _appDbContext.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetById(int id)
        {
            var result = await _appDbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task Add(Actor actor)
        { 
            await _appDbContext.Actors.AddAsync(actor);
           await _appDbContext.SaveChangesAsync();
        }

        public Task<Actor> Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
