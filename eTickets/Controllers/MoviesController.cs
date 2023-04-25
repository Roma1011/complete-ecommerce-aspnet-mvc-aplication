using eTickets.Data;
using eTickets.Data.ModelView;
using eTickets.Services.Actors;
using eTickets.Services.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IMoviesService _service;
        public MoviesController(IMoviesService service,IActorsService actorsService)
		{
            _service = service;
        }
		public async Task<IActionResult> Index()
        {
            var allMovies =await _service.GetAll(x=>x.Cinema);
			return View(allMovies);
		}

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAll(x => x.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filter=allMovies.Where(n=>n.Name.Contains(searchString)|| n.Description.Contains(searchString)).ToList();

                return View("Index",filter);
            }

            return View("Index",allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieById(id);
            return View(movieDetail);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");

                return View(movie);
            }

            await _service.AddMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var movieDetails = await _service.GetMovieById(id);

            if (movieDetails == null) return View("NotFound");

            var response = new MovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };


            var movieDropdownsData = await _service.GetMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,MovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");

                return View(movie);
            }

            await _service.UpdateMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieDetails = await _service.GetMovieById(id);
            if (movieDetails == null)
                return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
