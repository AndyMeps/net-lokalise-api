using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Responses
{
    internal class ContributorsResponse
    {
        [JsonPropertyName("contributors")]
        public IEnumerable<ContributorResponse> Contributors { get; set; }
    }
}
