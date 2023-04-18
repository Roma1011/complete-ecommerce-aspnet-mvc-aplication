using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using eTickets.Models;
using eTickets.Services;

namespace eTickets.Controllers
{
	public class ActorsController : Controller
	{
		private readonly IActorsService _actorsService;

		public ActorsController(IActorsService actorsService)
		{
            _actorsService = actorsService;
		}

		public async Task<IActionResult> Index()
        {
            var data=await _actorsService.GetAll();
			return View(data);
		}

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fullname,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorsService.Add(actor);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails =await _actorsService.GetById(id);
            if (actorDetails == null) 
                return View("Empty");

            return View(actorDetails);
        }
    }
}
