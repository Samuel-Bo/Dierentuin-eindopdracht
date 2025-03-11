using Dierentuin_eindopdracht.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dierentuin_eindopdracht.Controllers.Mvc
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ZooDbContext _context;

        public HomeController(ILogger<HomeController> logger, ZooDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var zooName = _context.Zoos.FirstOrDefault()?.Name ?? "Unknown Zoo";
            ViewBag.ZooName = zooName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
