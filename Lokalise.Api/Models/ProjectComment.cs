using Lokalise.Api.Collections.Comments.Responses;

namespace Lokalise.Api.Models
{
    public sealed class ProjectComment : ProjectEntity<Comment>
    {
        internal ProjectComment(ProjectCommentResponse response)
            : base(response.ProjectId, response.Comment is object ? new Comment(response.Comment) : null)
        {

        }
    }
}
