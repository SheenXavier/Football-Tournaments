using Microsoft.AspNetCore.Mvc;
using Tournaments.Models;
using Tournaments.Data;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
            // Retrieve the tournament data from TempData
            int tournamentId = (int)TempData["TournamentId"];
            string tournamentName = (string)TempData["TournamentName"];

            // Fetch the teams for the selected tournament
            var teams = _context.Team
                .Where(t => t.TournamentId == tournamentId)
                .Include(t => t.Tournament)  // Ensure the related Tournament details are loaded
                .ToList();

            if (!teams.Any())
            {
                return NotFound(); // Return 404 if no teams are found for the tournament
            }

            return View(teams); // Pass the list of teams directly to the view
        }

    }
}
