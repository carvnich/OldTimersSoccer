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

            // Filter by schedule type
            matches = league switch
            {
                "Spence Cup" => matches.Where(m => m.ScheduleType == "Spence Cup").ToList(),
                "Challenge Cup" => matches.Where(m => m.ScheduleType == "Challenge Cup").ToList(),
                _ => matches.Where(m => m.ScheduleType == "Regular").ToList()
            };

            ViewBag.Division = division;
            ViewBag.League = league;
            return PartialView("_SchedulePartial", matches);
        }

        public async Task<IActionResult> Standings(string division, string league)
        {
            var standings = await _soccerService.GetStandingsAsync();

            // Filter by schedule type if available
            standings = league switch
            {
                "Spence Cup" => standings.Where(s => s.ScheduleType == "Spence Cup").ToList(),
                "Challenge Cup" => standings.Where(s => s.ScheduleType == "Challenge Cup").ToList(),
                _ => standings.Where(s => s.ScheduleType == "Regular" || string.IsNullOrEmpty(s.ScheduleType)).ToList()
            };

            ViewBag.Division = division;
            ViewBag.League = league;
            return PartialView("_StandingsPartial", standings);
        }

        public async Task<IActionResult> Scorers(string division, string league)
        {
            var scorers = await _soccerService.GetScorersAsync();

            // Filter by schedule type
            scorers = league switch
            {
                "Spence Cup" => scorers.Where(s => s.ScheduleType == "Spence Cup").ToList(),
                "Challenge Cup" => scorers.Where(s => s.ScheduleType == "Challenge Cup").ToList(),
                _ => scorers.Where(s => s.ScheduleType == "Regular").ToList()
            };

            ViewBag.Division = division;
            ViewBag.League = league;
            return PartialView("_ScorersPartial", scorers);
        }
    }
}