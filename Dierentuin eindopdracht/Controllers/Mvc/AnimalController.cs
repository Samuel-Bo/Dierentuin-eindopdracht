using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dierentuin_eindopdracht.Controllers.Mvc
{
    public class AnimalController : Controller
    {
        private readonly AnimalService animalService;

        public AnimalController(AnimalService _animalService)
        {
            animalService = _animalService;
        }

        //returns a razor view with all animal data
        public IActionResult Index()
        {
            var animals = animalService.GetAnimals();
            return View(animals);
        }

        //Api-endpoint that returns Json
        [HttpGet("api/animals")]
        public IActionResult Get()
        {
            var animals = animalService.GetAnimals();
            return Ok(animals);
        }
    }
}
