using Lokalise.Api.Collections.Projects.Responses;

namespace Lokalise.Api.Models
{
    public class DeletedProject
    {
        public string ProjectId { get; }

        public bool ProjectDeleted { get; }

        internal DeletedProject(DeletedProjectResponse response)
        {
            ProjectId = response.ProjectId;
            ProjectDeleted = response.ProjectDeleted;
        }
    }
}
