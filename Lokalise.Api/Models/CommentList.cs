using Lokalise.Api.Collections.Comments.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Lokalise.Api.Models
{
    public class CommentList : PagedList
    {
        public string ProjectId { get; }
        public IEnumerable<Comment> Comments { get; }

        internal CommentList(CommentListResponse response)
        {
            PageCount = response.PageCount;
            TotalCount = response.TotalCount;
            ProjectId = response.ProjectId;
            Comments = response.Comments is object ? response.Comments.Select(c => new Comment(c)) : null;
        }
    }
}
