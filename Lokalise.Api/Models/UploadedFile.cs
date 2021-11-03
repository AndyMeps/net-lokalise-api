using Lokalise.Api.Collections.Files.Responses;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class UploadedFile : LocationEntity
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; }

        [JsonPropertyName("process")]
        public QueuedProcess Process { get; }

        internal UploadedFile(UploadedFileResponse response)
        {
            Location = response.Location;
            ProjectId = response.ProjectId;
            Process = response.Process is object ? new QueuedProcess(response.Process) : null;
        }
    }
}