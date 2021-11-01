using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class UploadedFile
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("process")]
        public QueuedProcess Process { get; set; }

        [JsonIgnore]
        public string Location { get; set; }

        public override string ToString()
        {
            return Location;
        }
    }
}