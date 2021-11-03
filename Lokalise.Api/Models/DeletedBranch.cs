using Lokalise.Api.Collections.Branches.Responses;

namespace Lokalise.Api.Models
{
    public class DeletedBranch
    {
        public string ProjectId { get; }
        public bool BranchDeleted { get; }

        internal DeletedBranch(DeletedBranchResponse response)
        {
            ProjectId = response.ProjectId;
            BranchDeleted = response.BranchDeleted;
        }
    }
}
