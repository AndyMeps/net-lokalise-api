using Lokalise.Api.Collections.Contributors.Responses;

namespace Lokalise.Api.Models
{
    public class DeletedContributor
    {
        public string ProjectId { get; }
        public bool ContributorDeleted { get; }

        internal DeletedContributor(DeletedContributorResponse response)
        {
            ProjectId = response.ProjectId;
            ContributorDeleted = response.ContributorDeleted;
        }
    }
}
