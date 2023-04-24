using eTickets.Data.Base;
using eTickets.Data.ModelView;
using eTickets.Models;

namespace eTickets.Services.Movies
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieById(int id);
        Task<MovieDropdownsVm> GetMovieDropdownsValues();
    }
}
