using Lokalise.Api.Collections.Projects.Responses;

namespace Lokalise.Api.Models
{
    public class EmptiedProject
    {
        public string ProjectId { get; }

        public bool KeysDeleted { get; }

        internal EmptiedProject(EmptiedProjectResponse response)
        {
            ProjectId = response.ProjectId;
            KeysDeleted = response.KeysDeleted;
        }
    }
}
