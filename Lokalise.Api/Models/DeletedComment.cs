using Lokalise.Api.Collections.Comments.Responses;

namespace Lokalise.Api.Models
{
    public class DeletedComment
    {
        public string ProjectId { get; }
        public bool CommentDeleted { get; }

        internal DeletedComment(DeletedCommentResponse response)
        {
            ProjectId = response.ProjectId;
            CommentDeleted = response.CommentDeleted;
        }
    }
}
