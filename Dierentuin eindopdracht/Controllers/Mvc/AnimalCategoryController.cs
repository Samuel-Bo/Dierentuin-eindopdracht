using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Mvc;
namespace Dierentuin_eindopdracht.Controllers.Mvc
{
    //this controller inherits all the functionalities from the it's category service and returns it to the view
    [Route("Categories")]
    public class AnimalCategoryController : Controller
    {
        private readonly AnimalCategoryService categoryService;
        private readonly AnimalService animalService;
        public AnimalCategoryController(AnimalCategoryService _categoryService, AnimalService _animalService)
        {
            categoryService = _categoryService;
            animalService = _animalService;
        }

        [HttpGet("Index")]
        public IActionResult Index() //return index of categories
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet("CategoryAnimals")]
        public IActionResult CategoryAnimals(int categoryId) //return category's animals by Id to the view
        {
            var categories = categoryService.GetCategoryAnimals(categoryId);
            return View(categories);
        }

        [HttpGet("Create")]
        public IActionResult Create()//Shows the creating view for categories, we need this to acces the create page 
        {
            var animals = animalService.EmptyCategoryGet();//need this for efficiency
            ViewBag.EmptyAnimals = animals;
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(AnimalCategoryDto categoryDto)//Actually Creates the enclosure and returns to the index after valid creation
        {
            if (!ModelState.IsValid)
            {
                var animals = animalService.EmptyCategoryGet();
                ViewBag.EmptyAnimals = animals;

                return View(categoryDto); //we need this to help catch the savechanges error and return us to the creation page
            }

            categoryService.CreateCategory(categoryDto);

            return RedirectToAction("Index");
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)//shows us the enclosure data when you edit the enclosure
        {
            var categoryDto = categoryService.ShowCategory(id);

            var animals = animalService.CategoryGet(id); //returns animals from the category
            ViewBag.CategoryAnimals = animals;

            var emptyAnimals = animalService.EmptyCategoryGet(); //returns animals where category is null
            ViewBag.EmptyAnimals = emptyAnimals;

            ViewData["CategoryId"] = id;

            return View(categoryDto);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(int id, AnimalCategoryDto categoryDto)//actually edits the enclosure
        {
            var category = categoryService.FindCategory(id);

            if (category == null)
            {
                return RedirectToAction("Index", "AnimalCategory");
            }

            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = id;

                var animals = animalService.CategoryGet(id);
                ViewBag.CategoryAnimals = animals;

                var emptyAnimals = animalService.EmptyCategoryGet(); 
                ViewBag.EmptyAnimals = emptyAnimals;

                return View(categoryDto);
            }

            categoryService.EditCategory(id, categoryDto);

            return RedirectToAction("Index", "AnimalCategory");
        }

        [HttpGet] 
        public IActionResult Delete(int id) //deleting animals
        {
            categoryService.DeleteCategory(id);

            return RedirectToAction("Index", "AnimalCategory");
        }

        //!!---API EXCLUSIVE---!!

        [HttpGet("api/categories")]
        public IActionResult Get()
        {
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }

    }
}
