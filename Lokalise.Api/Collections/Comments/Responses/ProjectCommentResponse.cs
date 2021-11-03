using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Comments.Responses
{
    internal class ProjectCommentResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("comment")]
        public CommentResponse Comment { get; set; }
    }
}
