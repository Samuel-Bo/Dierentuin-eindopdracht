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

        public IActionResult Index()
        {
            var animals = animalService.GetAnimals();
            return View(animals);
        }
    }
}
