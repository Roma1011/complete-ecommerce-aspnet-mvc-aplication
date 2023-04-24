using eTickets.Data;
using eTickets.Services.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IMoviesService _service;

		public MoviesController(IMoviesService service)
		{
            _service = service;
		}
		public async Task<IActionResult> Index()
        {
            var allMovies =await _service.GetAll(x=>x.Cinema);
			return View(allMovies);
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
	}
}
