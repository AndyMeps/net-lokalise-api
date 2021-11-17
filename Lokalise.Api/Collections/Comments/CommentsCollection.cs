using Lokalise.Api.Collections.Comments.Configurations;
using Lokalise.Api.Collections.Comments.Requests;
using Lokalise.Api.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lokalise.Api.Models;

namespace Lokalise.Api.Collections.Comments
{
    internal class CommentsCollection : BaseCollection, ICommentsCollection
    {
        internal CommentsCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        public Task<CommentList?> CreateAsync(string projectId, long keyId, string comment)
        {
            return CreateAsync(projectId, keyId, new[] { comment });
        }

        public async Task<CommentList?> CreateAsync(string projectId, long keyId, IEnumerable<string> comments)
        {
            var result = await PostAsync<CreateCommentRequest, CommentList>(
                CommentUri(projectId, keyId),
                new CreateCommentRequest(comments));

            return result;
        }

        public async Task<DeletedComment?> DeleteAsync(string projectId, long keyId, long commentId)
        {
            var result = await DeleteAsync<DeletedComment>(CommentUri(projectId, keyId, commentId));

            return result;
        }

        public async Task<CommentList?> ListAsync(string projectId, Action<ListCommentsConfiguration>? options = null)
        {
            var cfg = new ListCommentsConfiguration();
            options?.Invoke(cfg);

            var requestUri = $"{CommentUri(projectId.IncludeBranchName(cfg.Branch))}{cfg.ToQueryString()}";
            var result = await GetListAsync<CommentList>(requestUri);

            return result;
        }

        public async Task<CommentList?> ListAsync(string projectId, long keyId, Action<ListCommentsConfiguration>? options = null)
        {
            var cfg = new ListCommentsConfiguration();
            options?.Invoke(cfg);

            var requestUri = $"{CommentUri(projectId.IncludeBranchName(cfg.Branch), keyId)}{cfg.ToQueryString()}";
            var result = await GetListAsync<CommentList>(requestUri);

            return result;
        }

        public async Task<ProjectComment?> RetrieveAsync(string projectId, long keyId, long commentId)
        {
            var result = await GetAsync<ProjectComment>(CommentUri(projectId, keyId, commentId));

            return result;
        }

        private string CommentUri(string projectId, long? keyId = null, long? commentId = null)
        {
            var sb = new StringBuilder();
            sb.Append($"projects/{projectId}");

            if (!keyId.HasValue)
            {
                sb.Append("/comments");
                return sb.ToString();
            }

            sb.Append($"/keys/{keyId}/comments");

            if (!commentId.HasValue)
                return sb.ToString();

            sb.Append($"/{commentId}");

            return sb.ToString();
        }
    }
}
