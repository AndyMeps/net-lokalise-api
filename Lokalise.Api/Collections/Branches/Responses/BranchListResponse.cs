using Lokalise.Api.Responses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Branches.Responses
{
    internal class BranchListResponse : PagedListResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("branches")]
        public IEnumerable<BranchResponse> Branches { get; set; }
    }
}
