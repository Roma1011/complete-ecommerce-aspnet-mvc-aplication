﻿using eTickets.Data;
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

        public Task<Actor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Add(Actor actor)
        {
            throw new NotImplementedException();
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