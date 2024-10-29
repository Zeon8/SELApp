using System.Text.Json.Serialization;

namespace SELApp.Models
{
    public record User
    {
        [JsonPropertyName("id")]
        public required int Id { get; init; }

        [JsonPropertyName("t_name")]
        public required string FullName { get; init; }

        [JsonPropertyName("short_t_name")]
        public required string ShortName { get; init; }

        [JsonPropertyName("access_token")]
        public required string AccessToken { get; init; }

        [JsonPropertyName("firebase_token")]
        public required string FirebaseToken { get; init; }
    };
}
