using Lokalise.Api.Responses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Projects.Responses
{
    internal class ProjectListResponse : PagedListResponse
    {
        [JsonPropertyName("projects")]
        public IEnumerable<ProjectResponse> Projects { get; set; }
    }
}
