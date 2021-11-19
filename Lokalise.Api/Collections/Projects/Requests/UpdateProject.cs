using Lokalise.Api.Collections.Projects.Configurations;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Projects.Requests
{
    internal class UpdateProject
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("description")]
        public string? Description { get; }

        internal UpdateProject(string name, UpdateProjectConfiguration? options = null)
        {
            Name = name;
            Description = options?.Description;
        }
    }
}
