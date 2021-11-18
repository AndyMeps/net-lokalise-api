using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class ProjectStatistics
    {
        [JsonPropertyName("progress_total")]
        public short ProgressTotal { get; set; }

        [JsonPropertyName("keys_total")]
        public long KeysTotal { get; set; }

        [JsonPropertyName("team")]
        public long Team { get; set; }

        [JsonPropertyName("base_words")]
        public long BaseWords { get; set; }

        [JsonPropertyName("qa_issues_total")]
        public long QaIssuesTotal { get; set; }

        [JsonPropertyName("qa_issues")]
        public ProjectQaIssues? QaIssues { get; set; }

        [JsonPropertyName("languages")]
        public IEnumerable<LanguageStatistics>? Languages { get; set; }
    }
}
