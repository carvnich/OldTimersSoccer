using OldTimersSoccer.Models;

namespace OldTimersSoccer.Services
{
    public interface ISoccerService
    {
        Task<List<Match>> GetMatchesAsync(int year = 2025);
        Task<List<Standing>> GetStandingsAsync(int year = 2025);
        Task<List<Scorer>> GetScorersAsync(int year = 2025);
        Task<List<Player>> GetGamePlayersAsync(string teamId, int year = 2025, string playerType = "O");
    }
}
