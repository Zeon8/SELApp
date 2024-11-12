using System.Text.Json.Serialization;

namespace SELApp.Models.Schedule
{
    public record Schedule
    {
        [JsonPropertyName("schedule")]
        public required IEnumerable<Class> Classes { get; init; }
    }
}
