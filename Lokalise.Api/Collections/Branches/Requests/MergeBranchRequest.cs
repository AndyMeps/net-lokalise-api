using Lokalise.Api.Collections.Branches.Configurations;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Branches.Requests
{
    internal class MergeBranchRequest
    {
        [JsonPropertyName("force_conflic_resolve_using")]
        public string? ForceConflictResolveUsing { get; set; }

        [JsonPropertyName("target_branch_id")]
        public long? TargetBranchId { get; set; }

        internal MergeBranchRequest(MergeBranchConfiguration? options)
        {
            ForceConflictResolveUsing = options?.ForceConflictResolveUsing;
            TargetBranchId = options?.TargetBranchId;
        }
    }
}
