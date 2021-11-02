using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class MergedBranch
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("branch_deleted")]
        public bool BranchMerged { get; set; }

        [JsonPropertyName("branch")]
        public Branch Branch { get; set; }

        [JsonPropertyName("target_branch")]
        public Branch TargetBranch { get; set; }
    }
}
