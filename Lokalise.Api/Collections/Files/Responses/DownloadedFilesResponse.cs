using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Files.Responses
{
    public class DownloadedFilesResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("bundle_url")]
        public string BundleUrl { get; set; }
    }
}