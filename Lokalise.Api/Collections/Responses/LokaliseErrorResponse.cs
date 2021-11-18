using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Responses
{
    internal class LokaliseErrorResponse
    {
        [JsonPropertyName("error")]
        public LokaliseError? Error { get; init; }
    }
}
