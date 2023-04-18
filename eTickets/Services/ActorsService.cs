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

        public async Task<Actor> Update(int id, Actor newActor)
        {
            _appDbContext.Update(newActor);
            await _appDbContext.SaveChangesAsync();
            return newActor;
        }

        public async Task Delete(int id)
        {
            var result = await _appDbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _appDbContext.Actors.Remove(result);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
