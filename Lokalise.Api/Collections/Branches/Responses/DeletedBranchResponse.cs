using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Branches.Responses
{
    internal class DeletedBranchResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("branch_deleted")]
        public bool BranchDeleted { get; set; }
    }
}
