using Lokalise.Api.Collections.Branches.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Lokalise.Api.Models
{
    public class BranchList : PagedList
    {
        public string ProjectId { get; }

        public IEnumerable<Branch> Branches { get; }

        internal BranchList(BranchListResponse response)
        {
            ProjectId = response.ProjectId;
            Branches = response.Branches.Select(b => new Branch(b));
            TotalCount = response.TotalCount;
            PageCount = response.PageCount;
        }
    }
}
