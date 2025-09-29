using System.Text.Json.Serialization;

namespace OldTimersSoccer.Models
{
    public class Standing
    {
        [JsonPropertyName("division_id")]
        public string DivisionId { get; set; }

        [JsonPropertyName("division_name")]
        public string DivisionName { get; set; }

        [JsonPropertyName("standing")]
        public string TeamStanding { get; set; }

        [JsonPropertyName("team_name")]
        public string TeamName { get; set; }

        [JsonPropertyName("games_played")]
        public string GamesPlayed { get; set; }

        [JsonPropertyName("wins_total")]
        public string WinsTotal { get; set; }

        [JsonPropertyName("draws_total")]
        public string DrawsTotal { get; set; }

        [JsonPropertyName("loses_total")]
        public string LosesTotal { get; set; }

        [JsonPropertyName("points_total")]
        public string PointsTotal { get; set; }

        [JsonPropertyName("goals_for")]
        public string GoalsFor { get; set; }

        [JsonPropertyName("goals_against")]
        public string GoalsAgainst { get; set; }

        [JsonPropertyName("goals_diff")]
        public string GoalsDiff { get; set; }
    }
}
