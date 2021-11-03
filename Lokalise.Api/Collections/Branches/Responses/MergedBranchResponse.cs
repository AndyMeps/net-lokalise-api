using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Branches.Responses
{
    internal class MergedBranchResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("branch_deleted")]
        public bool BranchMerged { get; set; }

        [JsonPropertyName("branch")]
        public BranchResponse Branch { get; set; }

        [JsonPropertyName("target_branch")]
        public BranchResponse TargetBranch { get; set; }
    }
}
