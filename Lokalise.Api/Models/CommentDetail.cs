using Lokalise.Api.Collections.Comments.Responses;

namespace Lokalise.Api.Models
{
    public class CommentDetail
    {
        public string ProjectId { get; }

        public Comment Comment { get; }

        internal CommentDetail(CommentDetailResponse response)
        {
            ProjectId = response.ProjectId;
            Comment = response.Comment is object ? new Comment(response.Comment) : null;
        }
    }
}
