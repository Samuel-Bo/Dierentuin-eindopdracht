using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dierentuin_eindopdracht.Controllers.Mvc
{
    public class AnimalController : Controller
    {
        private readonly AnimalService animalService;
        private readonly EnclosureService enclosureService;
        private readonly AnimalCategoryService categoryService;
        public AnimalController(AnimalService _animalService, EnclosureService _enclosureService, AnimalCategoryService _categoryService)
        {
            animalService = _animalService;
            enclosureService = _enclosureService;
            categoryService = _categoryService;
        }

        //returns a razor view with all animal data
        public IActionResult Index()
        {
            var animals = animalService.GetAnimals();
            return View(animals);
        }

        [HttpGet("Create")]
        public IActionResult Create()//Shows the creating view for creating animals, we need this to acces the create page 
        {
            var enclosures = enclosureService.GetEnclosures();
            ViewBag.Enclosures = enclosures;  //need this for easier display in form

            var categories = categoryService.GetCategories();
            ViewBag.Categories = categories;  //need this for easier display in form

            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(AnimalDto animalDto)//Actually Creates the animal and returns to the index after valid creation
        {
            if (!ModelState.IsValid)
            {
                return View(animalDto); //we need this to help catch the savechanges error and return us to the creation page
            }

            animalService.CreateAnimal(animalDto);

            return RedirectToAction("Index");
        }


        //---API EXCLUSIVE!!!---

        [HttpGet("api/animals")]
        public IActionResult Get()
        {
            var animals = animalService.GetAnimals();
            return Ok(animals);
        }

    }
}
