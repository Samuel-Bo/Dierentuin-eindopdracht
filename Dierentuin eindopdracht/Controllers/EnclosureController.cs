using Dierentuin_eindopdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dierentuin_eindopdracht.Controllers
{
    public class EnclosureController : Controller
    {
        private readonly ZooDbContext context;
        public EnclosureController(ZooDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var enclosures = context.Enclosures.ToList();
            return View(enclosures);
        }
    }
}   
