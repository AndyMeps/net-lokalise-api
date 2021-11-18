using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class NewContributor
    {
        /// <summary>
        /// E-mail associated with this user.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; }


        /// <summary>
        /// Full name as set by the user.
        /// </summary>

        [JsonPropertyName("fullname")]
        public string Fullname { get; }



        /// <summary>
        /// Whether the user has Admin access to the project.
        /// </summary>
        [JsonPropertyName("is_admin")]
        public bool? IsAdmin { get; }



        /// <summary>
        /// Wheter the user has Reviewer access to the project.
        /// </summary>
        [JsonPropertyName("is_reviewer")]
        public bool? IsReviewer { get; }



        /// <summary>
        /// List of languages, accessible to the user.
        /// </summary>
        [JsonPropertyName("languages")]
        public IEnumerable<ContributorLanguage>? Languages { get; }



        /// <summary>
        /// List of user permissions.
        /// </summary>
        [JsonPropertyName("admin_rights")]
        public IEnumerable<string>? AdminRights { get; }

        public NewContributor(
            string email,
            string fullName,
            bool? isAdmin,
            bool? isReviewer,
            IEnumerable<ContributorLanguage>? languages = null,
            IEnumerable<string>? adminRights = null)
        {
            Email = email;
            Fullname = fullName;
            IsAdmin = isAdmin;
            IsReviewer = isReviewer;
            Languages = languages;
            AdminRights = adminRights;
        }
    }
}
