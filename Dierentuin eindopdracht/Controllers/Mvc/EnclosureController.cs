using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dierentuin_eindopdracht.Controllers.Mvc
{
    public class EnclosureController : Controller
    {
        private readonly EnclosureService enclosureService;
        public EnclosureController(EnclosureService _enclosureService)
        {
            enclosureService = _enclosureService;
        }
        public IActionResult Index()
        {
            var enclosures = enclosureService.GetEnclosures();
            return View(enclosures);
        }
    }
}
