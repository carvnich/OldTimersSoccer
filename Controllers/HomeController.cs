using Microsoft.AspNetCore.Mvc;
using OldTimersSoccer.Services;

namespace OldTimersSoccer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISoccerService _soccerService;

        public HomeController(ISoccerService soccerService)
        {
            _soccerService = soccerService;
        }

        public async Task<IActionResult> Index()
        {
            var standings = await _soccerService.GetStandingsAsync();
            ViewBag.Division = standings.FirstOrDefault()?.DivisionId ?? "A DIVISION";
            return View(standings);
        }

        public async Task<IActionResult> Standings(string division)
        {
            var standings = await _soccerService.GetStandingsAsync();
            ViewBag.Division = division;
            return PartialView("_StandingsPartial", standings);
        }

        public async Task<IActionResult> Scorers(string division)
        {
            var scorers = await _soccerService.GetScorersAsync();
            ViewBag.Division = division;
            return PartialView("_ScorersPartial", scorers);
        }
    }
}