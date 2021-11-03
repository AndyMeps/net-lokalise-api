using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Comments.Responses
{
    internal class DeletedCommentResponse
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("comment_deleted")]
        public bool CommentDeleted { get; set; }
    }
}
