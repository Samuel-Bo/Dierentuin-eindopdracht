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
        public AnimalCategoryController(AnimalCategoryService _categoryService)
        {
            categoryService = _categoryService;
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
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(AnimalCategoryDto categoryDto)//Actually Creates the enclosure and returns to the index after valid creation
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto); //we need this to help catch the savechanges error and return us to the creation page
            }

            categoryService.CreateCategory(categoryDto);

            return RedirectToAction("Index");
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
