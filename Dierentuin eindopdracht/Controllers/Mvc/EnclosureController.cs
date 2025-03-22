using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Dierentuin_eindopdracht.Controllers.Mvc
{
    //this controller inherits all the functionalities from the it's enclosure service and returns it to the view
    [Route("Enclosures")]
    public class EnclosureController : Controller
    {
        private readonly EnclosureService enclosureService;
        private readonly AnimalService animalService;
        public EnclosureController(EnclosureService _enclosureService, AnimalService animalService)
        {
            enclosureService = _enclosureService;
            this.animalService = animalService;
        }

        [HttpGet("Index")]
        public IActionResult Index() //normal index
        {
            var enclosures = enclosureService.GetEnclosures();
            return View(enclosures);
        }

        [HttpGet("EnclosureAnimals")]
        public IActionResult EnclosureAnimals(int enclosureId) //Returns an enclosure with it's animals to the view
        {
            Console.WriteLine($"DEBUG: Ontvangen EnclosureId = {enclosureId}");

            var enclosures = enclosureService.GetEnclosureAnimals(enclosureId);

            return View("EnclosureAnimals", enclosures);
        }

        [HttpGet("Create")]
        public IActionResult Create()//Shows the creating view for enclosures, we need this to acces the create page 
        {
            var animals = animalService.EmptyEnclosureGet();
            ViewBag.EmptyAnimals = animals;  //need this for easier display in html form
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(EnclosureDto enclosureDto)//Actually Creates the enclosure and returns to the index after valid creation
        {
            if (!ModelState.IsValid)
            {
                var animals = animalService.EmptyEnclosureGet();
                ViewBag.EmptyAnimals = animals; 

                return View(enclosureDto); //we need this to help catch the savechanges error and return us to the creation page
            }

            enclosureService.CreateEnclosure(enclosureDto);

            return RedirectToAction("Index");
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)//shows us the enclosure data when you edit the enclosure
        {
            var enclosureDto = enclosureService.ShowEnclosure(id);

            var animals = animalService.EnclosureGet(id); //returns animals in enclosure
            ViewBag.EnclosureAnimals = animals;

            var emptyAnimals = animalService.EmptyEnclosureGet(); //Returns animals where enclosure null
            ViewBag.EmptyAnimals = emptyAnimals;

            ViewData["EnclosureId"] = id;

            return View(enclosureDto); 
        }

        [HttpPost("Edit")]
        public IActionResult Edit(int id, EnclosureDto enclosureDto)//actually edits the enclosure
        {
            var enclosure = enclosureService.FindEnclosure(id);

            if (enclosure == null)
            {
                return RedirectToAction("Index", "Enclosure");
            }

            if (!ModelState.IsValid)
            {
                ViewData["EnclosureId"] = id;

                var animals = animalService.EnclosureGet(id);
                ViewBag.EnclosureAnimals = animals;

                var emptyAnimals = animalService.EmptyEnclosureGet();
                ViewBag.EmptyAnimals = emptyAnimals;

                return View(enclosureDto);
            }

            enclosureService.EditEnclosure(id, enclosureDto);

            return RedirectToAction("Index", "Enclosure");
        }

        [HttpGet] //deleting Enclosures
        public IActionResult Delete(int id)
        {
            enclosureService.DeleteEnclosure(id);

            return RedirectToAction("Index", "Enclosure");
        }

        //!!---API EXCLUSIVE---!!

        [HttpGet("api/enclosures")] //api display of enclosures
        public IActionResult Get()
        {
            var enclosures = enclosureService.GetEnclosures();
            return Ok(enclosures);
        }
    }
}
