using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class DeletedComment
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("comment_deleted")]
        public bool CommentDeleted { get; set; }
    }
}
