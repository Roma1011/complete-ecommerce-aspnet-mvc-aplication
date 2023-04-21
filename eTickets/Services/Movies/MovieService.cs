using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Services.Movies
{
    public class MovieService:EntityBaseRepository<Movie>,IMoviesService
    {
        public MovieService(AppDbContext context) :base(context){}
    }
}
