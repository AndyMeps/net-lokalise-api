using System.Collections.Generic;
using System.Linq;

namespace Lokalise.Api.Collections.Comments.Requests
{
    internal class CreateCommentRequest
    {
        public IEnumerable<NewCommentDto> Comments { get; }

        internal CreateCommentRequest(IEnumerable<string> comments)
        {
            Comments = comments.Select(c => new NewCommentDto(c));
        }
    }
}
