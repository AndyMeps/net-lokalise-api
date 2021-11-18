using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class QueuedProcess
    {
        [JsonPropertyName("process_id")]
        public string? ProcessId { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("created_by")]
        public long CreatedBy { get; set; }

        [JsonPropertyName("created_by_email")]
        public string? CreatedByEmail { get; set; }

        [JsonPropertyName("created_at")]
        public string? CreatedAt { get; set; }

        [JsonPropertyName("created_at_timestamp")]
        public long CreatedAtTimestamp { get; set; }
    }
}