using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class DeletedContributor
    {
        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("contributor_deleted")]
        public bool ContributorDeleted { get; set; }
    }
}
