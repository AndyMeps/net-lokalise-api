using Lokalise.Api.Collections.Contributors.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Requests
{
    internal class UpdateContributorRequest
    {
        [JsonPropertyName("is_admin")]
        public bool? IsAdmin { get; set; }

        [JsonPropertyName("is_reviewer")]
        public bool? IsReviewer { get; set; }

        [JsonPropertyName("languages")]
        public IEnumerable<ContributorLanguageRequest>? Languages { get; set; }

        [JsonPropertyName("admin_rights")]
        public IEnumerable<string>? AdminRights { get; set; }

        internal UpdateContributorRequest(UpdateContributorConfiguration configuration)
        {
            IsAdmin = configuration.IsAdmin;
            IsReviewer = configuration.IsReviewer;
            Languages = configuration.Languages?.Select(l => new ContributorLanguageRequest(l));
            AdminRights = configuration.AdminRights;
        }
    }
}
