using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Projects.Responses
{
    public class EmptiedProjectResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("keys_deleted")]
        public bool KeysDeleted { get; set; }
    }
}
