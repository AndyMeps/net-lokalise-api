using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Clients.Requests
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
        public List<ProjectLanguage> Languages { get; private set; }

        [JsonPropertyName("base_lang_iso")]
        public string BaseLangIso { get; private set; }

        [JsonPropertyName("project_type")]
        public string ProjectType { get; private set; }

        internal CreateProjectRequest(string name, CreateProjectOptions options)
        {
            Name = name;
            TeamId = options?.TeamId;
            Description = options?.Description;
            Languages = options?.Languages != null && options.Languages.Count > 0 ? options.Languages : null;
            BaseLangIso = options?.BaseLangIso;
            ProjectType = options?.ProjectType;
        }
    }

    internal class UpdateProjectRequest
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        internal UpdateProjectRequest(string name, UpdateProjectOptions options)
        {
            Name = name;
            Description = options?.Description;
        }
    }
}
