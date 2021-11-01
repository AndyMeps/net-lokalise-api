using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class Project
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("created_at_timestamp")]
        public long CreatedAtTimestamp { get; set; }

        [JsonPropertyName("created_by")]
        public long CreatedBy { get; set; }

        [JsonPropertyName("created_by_email")]
        public string CreatedByEmail { get; set; }

        [JsonPropertyName("team_id")]
        public long TeamId { get; set; }

        [JsonPropertyName("base_language_id")]
        public long BaseLanguageId { get; set; }

        [JsonPropertyName("base_language_iso")]
        public string BaseLanguageIso { get; set; }

        [JsonPropertyName("settings")]
        public ProjectSettings Settings { get; set; }

        [JsonPropertyName("statistics")]
        public ProjectStatistics Statistics { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
