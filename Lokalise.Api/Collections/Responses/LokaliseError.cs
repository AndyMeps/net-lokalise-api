using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Responses
{
    public class LokaliseError
    {
        [JsonPropertyName("message")]
        public string? Message { get; init; }

        [JsonPropertyName("code")]
        public int? Code { get; init; }
    }
}
