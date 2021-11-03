using Lokalise.Api.Collections.Comments.Configurations;
using Lokalise.Api.Collections.Comments.Requests;
using Lokalise.Api.Collections.Comments.Responses;
using Lokalise.Api.Extensions;
using Lokalise.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Comments
{
    internal class CommentsCollection : BaseCollection, ICommentsCollection
    {
        internal CommentsCollection(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions) : base(httpClient, jsonSerializerOptions)
        {
        }

        private string CommentUri(string projectId, long? keyId = null, long? commentId = null)
        {
            var sb = new StringBuilder();
            sb.Append($"projects/{projectId}");

            if (!keyId.HasValue)
                return sb.ToString();

            sb.Append($"/keys/{keyId}");

            if (!commentId.HasValue)
                return sb.ToString();

            sb.Append($"/comments/{commentId}");

            return sb.ToString();
        }

        public Task<CommentList> CreateAsync(string projectId, long keyId, string comment)
        {
            return CreateAsync(projectId, keyId, new string[] { comment });
        }

        public async Task<CommentList> CreateAsync(string projectId, long keyId, IEnumerable<string> comments)
        {
            var result = await PostAsync<CreateCommentRequest, CommentListResponse>(CommentUri(projectId, keyId), new CreateCommentRequest(comments));

            return new CommentList(result);
        }

        public async Task<DeletedComment> DeleteAsync(string projectId, long keyId, long commentId)
        {
            var result = await DeleteAsync<DeletedCommentResponse>(CommentUri(projectId, keyId, commentId));

            return new DeletedComment(result);
        }

        public async Task<CommentList> ListAsync(string projectId, Action<ListCommentsConfiguration> options = null)
        {
            var cfg = new ListCommentsConfiguration();
            options?.Invoke(cfg);

            var result = await GetListAsync<CommentListResponse>(CommentUri(projectId.IncludeBranchName(cfg.Branch)));

            return new CommentList(result);
        }

        public async Task<CommentList> ListAsync(string projectId, long keyId, Action<ListCommentsConfiguration> options = null)
        {
            var cfg = new ListCommentsConfiguration();
            options?.Invoke(cfg);

            var result = await GetListAsync<CommentListResponse>(CommentUri(projectId.IncludeBranchName(cfg.Branch), keyId));

            return new CommentList(result);
        }

        public async Task<CommentDetail> RetrieveAsync(string projectId, long keyId, long commentId)
        {
            var result = await GetAsync<CommentDetailResponse>(CommentUri(projectId, keyId, commentId));

            return new CommentDetail(result);
        }
    }
}
