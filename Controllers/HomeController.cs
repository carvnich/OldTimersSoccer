using Microsoft.AspNetCore.Mvc;
using OldTimersSoccer.Services;

namespace OldTimersSoccer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISoccerService _soccerService;

        public HomeController(ISoccerService soccerService) => _soccerService = soccerService;

        public async Task<IActionResult> Index()
        {
            var standings = await _soccerService.GetStandingsAsync();
            ViewBag.Division = standings.FirstOrDefault()?.DivisionId ?? "A DIVISION";
            ViewBag.League = "Regular Season";
            return View(standings);
        }

        public async Task<IActionResult> Schedule(string division, string league)
        {
            var matches = await _soccerService.GetMatchesAsync();
            ViewBag.Division = division;
            ViewBag.League = league;
            return PartialView("_SchedulePartial", matches);
        }

        public async Task<IActionResult> Standings(string division, string league)
        {
            var standings = await _soccerService.GetStandingsAsync();
            ViewBag.Division = division;
            ViewBag.League = league;
            return PartialView("_StandingsPartial", standings);
        }

        public async Task<IActionResult> Scorers(string division, string league)
        {
            var scorers = await _soccerService.GetScorersAsync();
            ViewBag.Division = division;
            ViewBag.League = league;
            return PartialView("_ScorersPartial", scorers);
        }
    }
}