using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Responses
{
    internal class DeletedContributorResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("contributor_deleted")]
        public bool ContributorDeleted { get; set; }
    }
}
