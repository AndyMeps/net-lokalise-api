using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class File
    {
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("key_count")]
        public long KeyCount { get; set; }
    }
}
