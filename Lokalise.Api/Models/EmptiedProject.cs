using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class EmptiedProject
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("keys_deleted")]
        public bool KeysDeleted { get; set; }
    }
}
