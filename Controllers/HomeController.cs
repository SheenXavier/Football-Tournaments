using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tournaments.Models;
using Tournaments.Data;

namespace Tournaments.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _context;

        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var tournaments = _context.Tournament
                .ToList();

            // Pass the data to the View
            return View(tournaments);
        }

        public IActionResult TournamentDetails(int id, string name)
        {
            // Store tournament data in TempData
            TempData["TournamentId"] = id;
            TempData["TournamentName"] = name;

            // Redirect to the Tournament Details page
            return RedirectToAction("Index", "Tournament");  // Make sure it's directed to the correct action
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
