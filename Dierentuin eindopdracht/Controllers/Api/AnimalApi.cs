using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dierentuin_eindopdracht.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalApi : ControllerBase
    {
        private readonly AnimalService _animalService;

        public AnimalApi(AnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            var animals = _animalService.GetAnimals();
            return Ok(animals);
        }
    }
}
