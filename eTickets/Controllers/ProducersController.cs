using eTickets.Data;
using eTickets.Models;
using eTickets.Services.Producers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
	{
		private readonly IProducerService _service;

		public ProducersController(IProducerService service)
		{
            _service = service;
		}
		public  async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAll();
			return View(allProducers);
		}

        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails==null) return View("NotFound");

			return View(producerDetails);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fullname,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.Add(producer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Fullname,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if (id == producer.Id)
            {
                await _service.Update(id,producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
                return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
