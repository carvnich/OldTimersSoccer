using OldTimersSoccer.Models;
using System.Text.Json;

namespace OldTimersSoccer.Services
{
    public class SoccerService : ISoccerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://oldtimerssoccerleague.com/otsl_api.php";

        public SoccerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Match>> GetMatchesAsync(int year = 2025)
        {
            var url = $"{_baseUrl}?otsl_action=get_league_schedule&season_year={year}";
            return await FetchDataAsync<Match>(url);
        }

        public async Task<List<Standing>> GetStandingsAsync(int year = 2025)
        {
            var url = $"{_baseUrl}?otsl_action=show_standings&season_year={year}";
            return await FetchDataAsync<Standing>(url);
        }

        public async Task<List<Scorer>> GetScorersAsync(int year = 2025)
        {
            var url = $"{_baseUrl}?otsl_action=get_scorers&season_year={year}";
            return await FetchDataAsync<Scorer>(url);
        }

        public async Task<List<Player>> GetGamePlayersAsync(string teamId, int year = 2025, string playerType = "O")
        {
            var url = $"{_baseUrl}?otsl_action=get_game_players&team_id={teamId}&season_year={year}&player_type={playerType}";
            return await FetchDataAsync<Player>(url);
        }

        private async Task<List<T>> FetchDataAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<T>>(json);

            return data ?? new List<T>();
        }
    }
}
