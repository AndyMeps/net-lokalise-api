using Lokalise.Api.Responses;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Comments.Responses
{
    internal class CommentListResponse : PagedListResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("comments")]
        public IEnumerable<CommentResponse> Comments { get; set; }
    }
}
