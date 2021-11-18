using Lokalise.Api.Collections.Projects.Configurations;

namespace Lokalise.Api.Collections.Projects.Requests
{
    internal class UpdateProject
    {
        public string Name { get; }
        public string? Description { get; }

        internal UpdateProject(string name, UpdateProjectConfiguration? options = null)
        {
            Name = name;
            Description = options?.Description;
        }
    }
}
