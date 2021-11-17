using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class CommentList : PagedList
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("comments")]
        public IEnumerable<Comment> Comments { get; set; }
    }
}
