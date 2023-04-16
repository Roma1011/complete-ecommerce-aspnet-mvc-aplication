using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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
	}
}
