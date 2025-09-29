using System.Text.Json.Serialization;

namespace OldTimersSoccer.Models
{
    public class Player
    {
        [JsonPropertyName("player_id")]
        public string PlayerId { get; set; }

        [JsonPropertyName("shirt_no")]
        public string ShirtNo { get; set; }

        [JsonPropertyName("player_lname")]
        public string PlayerLastName { get; set; }

        [JsonPropertyName("player_fname")]
        public string PlayerFirstName { get; set; }

        [JsonPropertyName("player_dob")]
        public string PlayerDateOfBirth { get; set; }

        [JsonPropertyName("player_role")]
        public string PlayerRole { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("player_address1")]
        public string PlayerAddress1 { get; set; }

        [JsonPropertyName("player_address2")]
        public string PlayerAddress2 { get; set; }

        [JsonPropertyName("player_city")]
        public string PlayerCity { get; set; }

        [JsonPropertyName("player_postal")]
        public string PlayerPostal { get; set; }

        [JsonPropertyName("player_prov")]
        public string PlayerProvince { get; set; }

        [JsonPropertyName("player_gender")]
        public string PlayerGender { get; set; }

        [JsonPropertyName("player_email")]
        public string PlayerEmail { get; set; }

        [JsonPropertyName("player_phone")]
        public string PlayerPhone { get; set; }

        [JsonPropertyName("player_picture")]
        public string PlayerPicture { get; set; }
    }
}
