using System.Text.Json.Serialization;

namespace OldTimersSoccer.Models
{
    public class Match
    {
        [JsonPropertyName("game_date")]
        public string GameDate { get; set; }

        [JsonPropertyName("game_time")]
        public string GameTime { get; set; }

        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        [JsonPropertyName("schedule_type")]
        public string ScheduleType { get; set; }

        [JsonPropertyName("home_team_id")]
        public string HomeTeamId { get; set; }

        [JsonPropertyName("home_team")]
        public string HomeTeam { get; set; }

        [JsonPropertyName("away_team_id")]
        public string AwayTeamId { get; set; }

        [JsonPropertyName("away_team")]
        public string AwayTeam { get; set; }

        [JsonPropertyName("field_name")]
        public string FieldName { get; set; }

        [JsonPropertyName("game_status")]
        public string GameStatus { get; set; }

        [JsonPropertyName("home_team_score")]
        public string HomeTeamScore { get; set; }

        [JsonPropertyName("away_team_score")]
        public string AwayTeamScore { get; set; }

        [JsonPropertyName("division_id")]
        public string DivisionId { get; set; }

        [JsonPropertyName("division_name")]
        public string DivisionName { get; set; }
    }
}
