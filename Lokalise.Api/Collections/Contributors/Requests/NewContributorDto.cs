using Lokalise.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Requests
{
    internal class NewContributorDto
    {
        [JsonPropertyName("email")]
        public string Email { get; }

        [JsonPropertyName("fullname")]
        public string Fullname { get; }

        [JsonPropertyName("is_admin")]
        public bool? IsAdmin { get; }

        [JsonPropertyName("is_reviewer")]
        public bool? IsReviewer { get; }

        [JsonPropertyName("languages")]
        public IEnumerable<UserLanguageRequest> Languages { get; }

        [JsonPropertyName("admin_rights")]
        public IEnumerable<string> AdminRights { get; }
        internal NewContributorDto(NewContributor contributor)
        {
            Email = contributor.Email;
            Fullname = contributor.Fullname;
            IsAdmin = contributor.IsAdmin;
            IsReviewer = contributor.IsReviewer;
            Languages = contributor.Languages is object ? contributor.Languages.Select(l => new UserLanguageRequest(l)) : null;
            AdminRights = contributor.AdminRights;
        }
    }
}
