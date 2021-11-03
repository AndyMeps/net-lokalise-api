using Lokalise.Api.Collections.Projects.Configurations;

namespace Lokalise.Api.Collections.Projects.Requests
{
    internal class UpdateProjectRequest
    {
        public string Name { get; }
        public string Description { get; }

        internal UpdateProjectRequest(string name, UpdateProjectConfiguration options)
        {
            Name = name;
            Description = options?.Description;
        }
    }
}
