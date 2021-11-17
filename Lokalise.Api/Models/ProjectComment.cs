using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class ProjectComment
    {
        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("comment")]
        public Comment? Comment { get; set; }
    }
}
