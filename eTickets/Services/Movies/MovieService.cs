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
    }
}
