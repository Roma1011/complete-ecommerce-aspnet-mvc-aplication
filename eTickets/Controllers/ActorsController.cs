﻿using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
	public class ActorsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
