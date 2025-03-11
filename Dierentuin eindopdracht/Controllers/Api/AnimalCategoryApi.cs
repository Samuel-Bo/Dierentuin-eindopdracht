using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dierentuin_eindopdracht.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalCategoryApi : ControllerBase
    {
        private readonly AnimalCategoryService _categoryService;

        public AnimalCategoryApi(AnimalCategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalCategory>> Get()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }
    }
}
