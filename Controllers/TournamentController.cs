using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tournaments.Models;
using Tournaments.Data;


namespace Tournaments.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ILogger<TournamentController> _logger;
        private readonly AppDBContext _context;

        public TournamentController(ILogger<TournamentController> logger, AppDBContext context)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

