using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class DownloadedFiles
    {
        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("bundle_url")]
        public string? BundleUrl { get; set; }
    }
}