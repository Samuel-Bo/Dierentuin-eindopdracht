using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dierentuin_eindopdracht.Controllers.Mvc
{
    public class AnimalCategoryController : Controller
    {
        private readonly AnimalCategoryService categoryService;
        public AnimalCategoryController(AnimalCategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index() 
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}
