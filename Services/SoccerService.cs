using OldTimersSoccer.Models;
using System.Text.Json;

namespace OldTimersSoccer.Services
{
    public class SoccerService : ISoccerService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://oldtimerssoccerleague.com/otsl_api.php";

        public SoccerService(HttpClient httpClient) => _httpClient = httpClient;

        public Task<List<Standing>> GetStandingsAsync(int year = 2025) =>
            FetchDataAsync<Standing>($"{BaseUrl}?otsl_action=show_standings&season_year={year}");

        public Task<List<Scorer>> GetScorersAsync(int year = 2025) =>
            FetchDataAsync<Scorer>($"{BaseUrl}?otsl_action=get_scorers&season_year={year}");

        public Task<List<Match>> GetMatchesAsync(int year = 2025) =>
            FetchDataAsync<Match>($"{BaseUrl}?otsl_action=get_league_schedule&season_year={year}");

        public Task<List<Player>> GetGamePlayersAsync(string teamId, int year = 2025, string playerType = "O") =>
            FetchDataAsync<Player>($"{BaseUrl}?otsl_action=get_game_players&team_id={teamId}&season_year={year}&player_type={playerType}");

        private async Task<List<T>> FetchDataAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}