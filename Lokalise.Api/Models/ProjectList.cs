using Lokalise.Api.Collections.Projects.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Lokalise.Api.Models
{
    public class ProjectList : PagedList
    {
        public IEnumerable<Project> Projects { get; }

        internal ProjectList(ProjectListResponse response)
        {
            TotalCount = response.TotalCount;
            PageCount = response.PageCount;
            Projects = response.Projects is object ? response.Projects.Select(p => new Project(p)) : null;
        }
    }
}
