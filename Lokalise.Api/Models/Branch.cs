using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class Branch : LocationEntity
    {
        /// <summary>
        /// A unique identifier of the branch.
        /// </summary>
        [JsonPropertyName("branch_id")]
        public long BranchId { get; set; }

        /// <summary>
        /// Branch name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Date of branch creation.
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Unix timestamp when branch was created.
        /// </summary>
        [JsonPropertyName("created_at_timestamp")]
        public long CreatedAtTimestamp { get; set; }

        /// <summary>
        /// An identifier of a user who has created the branch.
        /// </summary>
        [JsonPropertyName("created_by")]
        public long CreatedBy { get; set; }

        /// <summary>
        /// An e-mail of a user who has created the branch.
        /// </summary>
        [JsonPropertyName("created_by_email")]
        public string CreatedByEmail { get; set; }
    }
}
