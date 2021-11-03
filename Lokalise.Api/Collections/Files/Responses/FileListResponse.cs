using Lokalise.Api.Responses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Files.Responses
{
    internal class FileListResponse : PagedListResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("files")]
        public IEnumerable<FileResponse> Files { get; set; }
    }
}
