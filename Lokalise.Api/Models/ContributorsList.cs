using Lokalise.Api.Collections.Contributors.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Lokalise.Api.Models
{
    public class ContributorsList : PagedList
    {
        public string ProjectId { get; }

        public IEnumerable<Contributor> Contributors { get; }

        internal ContributorsList(ContributorsListResponse response)
        {
            TotalCount = response.TotalCount;
            PageCount = response.PageCount;
            ProjectId = response.ProjectId;
            Contributors = response.Contributors.Select(c => new Contributor(c));
        }
    }
}
