using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Data.ModelView;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services.Movies
{
    public class MovieService:EntityBaseRepository<Movie>,IMoviesService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;

        }
        public async Task<Movie> GetMovieById(int id)
        {
            var movieDetails = _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return await movieDetails;
        }

        public async Task<MovieDropdownsVm> GetMovieDropdownsValues()
        {
            var response = new MovieDropdownsVm()
            {
                Actors = await _context.Actors.OrderBy(n => n.Fullname).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.Fullname).ToListAsync(),
            };

            return response;
        }

        public async Task AddMovie(MovieVM data)
        {
            var Movie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                CinemaId = data.CinemaId,
                StratDate = data.StratDate,
                EndDate = data.EndDate,
                ProducerId = data.ProducerId,
            };
           await _context.Movies.AddAsync(Movie);
           await _context.SaveChangesAsync();

           foreach (var actorId in data.ActorIds)
           {
               var newActorMovie = new Actor_Movie()
               {
                   MovieId = Movie.Id,
                   ActorId = actorId
               };
               await _context.Actors_Movies.AddAsync(newActorMovie);
           }

           await _context.SaveChangesAsync();
        }

        public async Task UpdateMovie(MovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageUrl = data.ImageUrl;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StratDate = data.StratDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();
            }
            var existingActorsDb=await _context.Actors_Movies.Where(n=>n.MovieId==data.Id).ToListAsync();
            _context.Actors_Movies.RemoveRange(existingActorsDb);

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

        }
    }
}
