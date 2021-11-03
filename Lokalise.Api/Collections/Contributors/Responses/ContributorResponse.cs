using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Responses
{
    internal class ContributorResponse
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("fullname")]
        public string Fullname { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("created_at_timestamp")]
        public long CreatedAtTimestamp { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("is_reviewer")]
        public bool IsReviewer { get; set; }

        [JsonPropertyName("languages")]
        public IEnumerable<UserLanguageResponse> Languages { get; set; }

        [JsonPropertyName("admin_rights")]
        public IEnumerable<string> AdminRights { get; set; }
    }
}
