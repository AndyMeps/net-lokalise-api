using Lokalise.Api.Collections.Branches.Responses;

namespace Lokalise.Api.Models
{
    public class MergedBranch
    {
        public string ProjectId { get; }
        public bool BranchMerged { get; }
        public Branch Branch { get; }
        public Branch TargetBranch { get; }

        internal MergedBranch(MergedBranchResponse response)
        {
            ProjectId = response.ProjectId;
            BranchMerged = response.BranchMerged;
            Branch = new Branch(response.Branch);
            TargetBranch = new Branch(response.TargetBranch);
        }
    }
}
