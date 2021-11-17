using Lokalise.Api.Collections.Projects.Configurations;
using Lokalise.Api.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Projects.Requests
{
    public class CreateProject
    {
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("team_id")]
        public long? TeamId { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("languages")]
        public IEnumerable<ProjectLanguage> Languages { get; }

        [JsonPropertyName("base_lang_iso")]
        public string BaseLangIso { get; }

        [JsonPropertyName("project_type")]
        public string ProjectType { get; }

        internal CreateProject(string name, CreateProjectConfiguration options)
        {
            Name = name;
            TeamId = options?.TeamId;
            Description = options?.Description;
            BaseLangIso = options?.BaseLangIso;
            ProjectType = options?.ProjectType;
            Languages = options?.Languages;
        }
    }
}
