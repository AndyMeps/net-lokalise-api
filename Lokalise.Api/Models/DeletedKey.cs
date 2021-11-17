using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class DeletedKey
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("key_deleted")]
        public bool KeyDeleted { get; set; }
    }
}
