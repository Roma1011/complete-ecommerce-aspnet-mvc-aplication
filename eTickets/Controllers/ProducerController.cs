﻿using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
	public class ProducerController : Controller
	{
		private readonly AppDbContext _context;

		public ProducerController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
