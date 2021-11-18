using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class ProjectKey
    {
        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("key")]
        public Key? Key { get; set; }
    }
}
