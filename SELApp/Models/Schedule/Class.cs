using System.Text.Json.Serialization;

namespace SELApp.Models.Schedule
{
    public record Class
    {
        [JsonPropertyName("id")]
        public required int Id { get; init; }

        [JsonPropertyName("date")]
        public required DateTime Date { get; init; }

        [JsonPropertyName("para")]
        public required int ClassNumber { get; init; }

        [JsonPropertyName("initial_plan_code")]
        public required string InitialPlanCode { get; init; }

        [JsonPropertyName("subject_name")]
        public required string SubjectName { get; init; }

        [JsonPropertyName("auditory_name")]
        public required string AuditoryName { get; init; }

        [JsonPropertyName("group_names")]
        public required string GroupNames { get; init; }
    }
}
