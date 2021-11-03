using System.Collections.Generic;

namespace Lokalise.Api.Models
{
    public class NewContributor
    {
        /// <summary>
        /// E-mail associated with this user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Full name as set by the user.
        /// </summary>
        public string Fullname { get; }

        /// <summary>
        /// Whether the user has Admin access to the project.
        /// </summary>
        public bool? IsAdmin { get; }

        /// <summary>
        /// Wheter the user has Reviewer access to the project.
        /// </summary>
        public bool? IsReviewer { get; }

        /// <summary>
        /// List of languages, accessible to the user.
        /// </summary>
        public IEnumerable<UserLanguage> Languages { get; }

        /// <summary>
        /// List of user permissions.
        /// </summary>
        public IEnumerable<string> AdminRights { get; }

        public NewContributor(
            string email,
            IEnumerable<UserLanguage> languages,
            string fullname = null,
            bool? isAdmin = null,
            bool? isReviewer = null,
            IEnumerable<string> adminRights = null)
        {
            Email = email;
            Languages = languages;

            Fullname = fullname;
            IsAdmin = isAdmin;
            IsReviewer = isReviewer;
            AdminRights = adminRights;
        }
    }
}
