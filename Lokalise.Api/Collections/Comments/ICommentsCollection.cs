using Lokalise.Api.Collections.Comments.Configurations;
using Lokalise.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Comments
{
    public interface ICommentsCollection
    {
        Task<CommentList> ListAsync(string projectId, Action<ListCommentsConfiguration> options = null);

        Task<CommentList> ListAsync(string projectId, long keyId, Action<ListCommentsConfiguration> options = null);

        Task<CommentList> CreateAsync(string projectId, long keyId, string comment);

        Task<CommentList> CreateAsync(string projectId, long keyId, IEnumerable<string> comments);

        Task<ProjectComment> RetrieveAsync(string projectId, long keyId, long commentId);

        Task<DeletedComment> DeleteAsync(string projectId, long keyId, long commentId);
    }
}
