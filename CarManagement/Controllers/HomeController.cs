using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarManagement.Models;
using Cosmonaut;
using Cosmonaut.Extensions;
using System.Net.Http;
using System;
using System.Security.Authentication;

namespace CarManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICosmosStore<Car> _cosmosStore;

        public HomeController(ICosmosStore<Car> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var cars = await _cosmosStore.Query().ToListAsync();
            return View(cars);

        }
        [HttpPost("delete/{carId}")]
        public async Task<IActionResult> DeleteCar(string carId)
        {
            await _cosmosStore.RemoveByIdAsync(carId);
            return RedirectToAction("Index");
        }

        [HttpPost("addcar")]
        public async Task<IActionResult> AddCar([FromForm] Car carToAdd)
        {
            await _cosmosStore.AddAsync(carToAdd);
            return RedirectToAction("Index");
        }

        [HttpPost("updatecar")]
        public async Task<IActionResult> Updatecar([FromForm] Car carToUpdate)
        {
            var result = await _cosmosStore.UpdateAsync(carToUpdate);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
