using Lokalise.Api.Collections.Comments.Responses;
using Lokalise.Api.Extensions;
using System;

namespace Lokalise.Api.Models
{
    public class Comment
    {
        /// <summary>
        /// A unique identifier of the comment.
        /// </summary>
        public long CommentId { get; }

        /// <summary>
        /// Identifier of a key, the comment is attached to.
        /// </summary>
        public long KeyId { get; }

        /// <summary>
        /// The comment.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Identifier of a user, who has left the comment.
        /// </summary>
        public long AddedBy { get; }

        /// <summary>
        /// E-mail of a user, who has left the comment.
        /// </summary>
        public string AddedByEmail { get; }

        /// <summary>
        /// Date and time the comment was added.
        /// </summary>
        public DateTime AddedAt { get; }

        internal Comment(CommentResponse response)
        {
            CommentId = response.CommentId;
            KeyId = response.KeyId;
            Content = response.Comment;
            AddedBy = response.AddedBy;
            AddedByEmail = response.AddedByEmail;
            AddedAt = response.AddedAtTimestamp.ToUtcDateTime();
        }
    }
}
