using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class DeletedProject
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("project_deleted")]
        public bool ProjectDeleted { get; set; }
    }
}
