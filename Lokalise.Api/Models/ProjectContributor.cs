using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class ProjectContributor
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("contributor")]
        public Contributor Contributor { get; set; }
    }
}
