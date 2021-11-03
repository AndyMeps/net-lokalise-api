using Lokalise.Api.Responses;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Files.Responses
{
    internal class UploadedFileResponse : LocationEntityResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("process")]
        public QueuedProcessResponse Process { get; set; }
    }
}