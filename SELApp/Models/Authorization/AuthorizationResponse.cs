using System.Text.Json.Serialization;

namespace SELApp.Models.Authorization
{
    public record AuthorizationResponse
    {
        [JsonPropertyName("user")]
        public required User User { get; init; }
    }
}
