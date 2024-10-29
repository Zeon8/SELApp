using System.Text.Json.Serialization;

namespace SELApp.Models
{
    public record AuthorizationResponse
    {
        [JsonPropertyName("user")]
        public required User User { get; init; }
    }
}
