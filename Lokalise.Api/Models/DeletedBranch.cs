using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class DeletedBranch
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("branch_deleted")]
        public bool BranchDeleted { get; set; }
    }
}
