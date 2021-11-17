using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class Comment
    {
        [JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [JsonPropertyName("key_id")]
        public long KeyId { get; set; }

        [JsonPropertyName("comment")]
        public string? Content { get; set; }

        [JsonPropertyName("added_by")]
        public long AddedBy { get; set; }

        [JsonPropertyName("added_by_email")]
        public string? AddedByEmail { get; set; }

        [JsonPropertyName("added_at")]
        public string? AddedAt { get; set; }

        [JsonPropertyName("added_at_timestamp")]
        public long AddedAtTimestamp { get; set; }
    }
}
