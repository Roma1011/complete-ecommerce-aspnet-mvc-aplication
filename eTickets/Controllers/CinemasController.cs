using eTickets.Data;
using eTickets.Models;
using eTickets.Services.Cinemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class CinemasController : Controller
	{
		private readonly ICinemasService _service;

		public CinemasController(ICinemasService service)
		{
            _service = service;
		}
		public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAll();
			return View(allProducers);
		}

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.Add(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails =await _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
                
            }
            await _service.Update(id,cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
