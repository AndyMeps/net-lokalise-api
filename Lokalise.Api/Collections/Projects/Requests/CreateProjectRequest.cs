using Lokalise.Api.Collections.Projects.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Projects.Requests
{
    internal class CreateProjectRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonPropertyName("team_id")]
        public long? TeamId { get; private set; }

        [JsonPropertyName("description")]
        public string Description { get; private set; }

        [JsonPropertyName("languages")]
        public IEnumerable<ProjectLanguageDto> Languages { get; private set; }

        [JsonPropertyName("base_lang_iso")]
        public string BaseLangIso { get; private set; }

        [JsonPropertyName("project_type")]
        public string ProjectType { get; private set; }

        internal CreateProjectRequest(string name, CreateProjectConfiguration options)
        {
            Name = name;
            TeamId = options?.TeamId;
            Description = options?.Description;
            BaseLangIso = options?.BaseLangIso;
            ProjectType = options?.ProjectType;
            Languages = options?.Languages != null && options.Languages.Count > 0
                ? options.Languages.Select(l => new ProjectLanguageDto(l)) 
                : null;
        }
    }
}
