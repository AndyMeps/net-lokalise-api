using Lokalise.Api.Collections.Contributors.Responses;
using Lokalise.Api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lokalise.Api.Models
{
    public class Contributor
    {
        /// <summary>
        /// A unique identifier of the user.
        /// </summary>
        public long UserId { get; }

        /// <summary>
        /// E-mail associated with this user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Full name as set by the user.
        /// </summary>
        public string Fullname { get; }

        /// <summary>
        /// Date/time at which the user was created.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Whether the user has Admin access to the project.
        /// </summary>
        public bool IsAdmin { get; }

        /// <summary>
        /// Wheter the user has Reviewer access to the project.
        /// </summary>
        public bool IsReviewer { get; }

        /// <summary>
        /// List of languages, accessible to the user.
        /// </summary>
        public IEnumerable<ContributorLanguage> Languages { get; }

        /// <summary>
        /// List of user permissions.
        /// </summary>
        public IEnumerable<string> AdminRights { get; }

        internal Contributor(ContributorResponse response)
        {
            UserId = response.UserId;
            Email = response.Email;
            Fullname = response.Fullname;
            CreatedAt = response.CreatedAtTimestamp.ToUtcDateTime();
            IsAdmin = response.IsAdmin;
            IsReviewer = response.IsReviewer;
            Languages = response?.Languages?.Select(l => new ContributorLanguage(l));
            AdminRights = response.AdminRights;
        }
    }
}
