using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Files.Responses
{
    internal class FileResponse
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        [JsonPropertyName("key_count")]
        public long KeyCount { get; set; }
    }
}
