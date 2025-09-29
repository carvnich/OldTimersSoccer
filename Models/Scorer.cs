using System.Text.Json.Serialization;

namespace OldTimersSoccer.Models
{
    public class Scorer
    {
        [JsonPropertyName("season_year")]
        public string SeasonYear { get; set; }

        [JsonPropertyName("schedule_type")]
        public string ScheduleType { get; set; }

        [JsonPropertyName("division_id")]
        public string DivisionId { get; set; }

        [JsonPropertyName("division_name")]
        public string DivisionName { get; set; }

        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        [JsonPropertyName("team_name")]
        public string TeamName { get; set; }

        [JsonPropertyName("player_id")]
        public string PlayerId { get; set; }

        [JsonPropertyName("player_lname")]
        public string PlayerLastName { get; set; }

        [JsonPropertyName("player_fname")]
        public string PlayerFirstName { get; set; }

        [JsonPropertyName("tot_goals")]
        public string TotalGoals { get; set; }
    }
}
