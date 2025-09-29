using Microsoft.AspNetCore.Mvc;
using OldTimersSoccer.Models;
using OldTimersSoccer.Services;
using System.Diagnostics;

namespace OldTimersSoccer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISoccerService _soccerService;

        public HomeController(ILogger<HomeController> logger, ISoccerService soccerService)
        {
            _logger = logger;
            _soccerService = soccerService;
        }

        public async Task<IActionResult> Index(string division = null)
        {
            var standings = await _soccerService.GetStandingsAsync();
            ViewBag.Division = division;
            return View(standings);
        }

        public async Task<IActionResult> Standings()
        {
            var standings = await _soccerService.GetStandingsAsync();
            return View(standings);
        }

        public async Task<IActionResult> Scorers()
        {
            var scorers = await _soccerService.GetScorersAsync();
            return View(scorers);
        }

        public async Task<IActionResult> Players(string teamId)
        {
            var players = await _soccerService.GetGamePlayersAsync(teamId);
            return View(players);
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
