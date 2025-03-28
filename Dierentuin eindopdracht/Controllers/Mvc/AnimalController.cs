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
        [HttpGet("Index")]
        public IActionResult Index(string searchstring)
        {
            var animals = animalService.GetAnimals();

            if (!String.IsNullOrEmpty(searchstring))
            {
                animals = animals
                            .Where(a =>
                                a.Name.ToLower().Contains(searchstring.ToLower())||
                                a.Species.ToLower().Contains(searchstring.ToLower())||
                                (a.Prey != null && a.Prey.ToLower().Contains(searchstring.ToLower()))||
                                a.SpaceRequirement.ToString().Contains(searchstring)||
                                a.FeedingTime.ToLower().Contains(searchstring.ToLower())||
                                a.Arise.ToString().ToLower().Contains(searchstring.ToLower())||
                                a.BedTime.ToString().ToLower().Contains(searchstring.ToLower())||
                                a.Size.ToString().ToLower().Contains(searchstring.ToLower())||
                                a.DietaryClass.ToString().ToLower().Contains(searchstring.ToLower())||
                                a.ActivityPattern.ToString().ToLower().Contains(searchstring.ToLower())||
                                a.SecurityRequirement.ToString().ToLower().Contains(searchstring.ToLower())||
                                (a.Enclosure != null && a.Enclosure.Name.ToLower().Contains(searchstring.ToLower()))||
                                (a.Category != null && a.Category.Name.ToLower().Contains(searchstring.ToLower()))
                            ).ToList();
            }
            return View(animals);

        }

        [HttpGet]
        public IActionResult Filter(string filter)
        {
            var animals = animalService.FilterAnimals(filter);

            return View("Index", animals);
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
                var enclosures = enclosureService.GetEnclosures(); // we are required to refill the dropdowns everytime we get an invalid errors otherwise the they will return null
                ViewBag.Enclosures = enclosures;  

                var categories = categoryService.GetCategories();
                ViewBag.Categories = categories;  

                return View(animalDto); //we need this to help catch the savechanges error and return us to the creation page
            }

            animalService.CreateAnimal(animalDto);

            return RedirectToAction("Index");
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)//shows us the animal data when you edit the animal
        {
            var animalDto = animalService.ShowAnimal(id);

            var enclosures = enclosureService.GetEnclosures();
            ViewBag.Enclosures = enclosures;  //need this for easier display in form

            var categories = categoryService.GetCategories();
            ViewBag.Categories = categories;  //need this for easier display in form

            ViewData["AnimalId"] = id;

            return View(animalDto);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(int id, AnimalDto animalDto)//actually edits the animal
        {
            var animal = animalService.FindAnimal(id);

            if (animal == null)
            {
                return RedirectToAction("Index", "Animal");
            }

            if (!ModelState.IsValid)
            {
                ViewData["AnimalId"] = id;

                var enclosures = enclosureService.GetEnclosures(); // we are required to refill the dropdowns everytime we get an invalid errors otherwise the they will return null
                ViewBag.Enclosures = enclosures;

                var categories = categoryService.GetCategories();
                ViewBag.Categories = categories;

                return View(animalDto);
            }

            animalService.EditAnimal(id, animalDto);

            return RedirectToAction("Index", "Animal");
        }

        [HttpGet] //deleting animals
        public IActionResult Delete(int id)
        {
            animalService.DeleteAnimal(id);

            return RedirectToAction("Index", "Animal");
        }

        [HttpGet]
        public IActionResult Sunset()
        {
            var animals = animalService.GetSunsetAnimals();

            return PartialView(animals);
        }

        [HttpGet]
        public IActionResult Sunrise()
        {
            var animals = animalService.GetSunriseAnimals();

            return PartialView(animals);
        }

        [HttpPost] 
        public IActionResult AutoAssign() //AutoAssign action 
        {
            animalService.AssignRandomEnclosures();

            return RedirectToAction("Index");
        }

        [HttpGet("FeedingTime")]
        public IActionResult FeedingTime(int id)
        {
            var animal = animalService.FindAnimal(id);

            return View(animal);
        }

        //!!---API EXCLUSIVE, NO VISUAL REPRESENTATION---!!

        [HttpGet("api/animals")]
        public IActionResult Get()
        {
            var animals = animalService.GetAnimals();
            return Ok(animals);
        }

    }
}
