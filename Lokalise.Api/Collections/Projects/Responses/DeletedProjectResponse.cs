using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Projects.Responses
{
    internal class DeletedProjectResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("project_deleted")]
        public bool ProjectDeleted { get; set; }
    }
}
