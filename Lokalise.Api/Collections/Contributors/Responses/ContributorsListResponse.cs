using Lokalise.Api.Responses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Responses
{
    internal class ContributorsListResponse : PagedListResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("contributors")]
        public IEnumerable<ContributorResponse> Contributors { get; set; }
    }
}
