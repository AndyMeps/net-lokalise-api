using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Responses
{
    internal class ProjectContributorResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("contributor")]
        public ContributorResponse Contributor { get; set; }
    }
}
