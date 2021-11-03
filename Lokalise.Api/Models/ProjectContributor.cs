using Lokalise.Api.Collections.Contributors.Responses;

namespace Lokalise.Api.Models
{
    public sealed class ProjectContributor : ProjectEntity<Contributor>
    {
        internal ProjectContributor(ProjectContributorResponse response)
            : base(response.ProjectId, response.Contributor is object ? new Contributor(response.Contributor) : null)
        {
        }

        public Contributor Contributor => Entity;
    }
}
