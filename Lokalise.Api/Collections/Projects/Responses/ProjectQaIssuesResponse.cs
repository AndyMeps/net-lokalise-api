using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Projects.Responses
{
    internal class ProjectQaIssuesResponse
    {
        [JsonPropertyName("not_reviewed")]
        public long NotReviewed { get; set; }

        [JsonPropertyName("unverified")]
        public long Unverified { get; set; }

        [JsonPropertyName("spelling_grammar")]
        public long SpellingGrammar { get; set; }

        [JsonPropertyName("inconsistent_placeholders")]
        public long InconsistentPlaceholders { get; set; }

        [JsonPropertyName("inconsistent_html")]
        public long InconsistentHtml { get; set; }

        [JsonPropertyName("different_number_of_urls")]
        public long DifferentNumberOfUrls { get; set; }

        [JsonPropertyName("different_urls")]
        public long DifferentUrls { get; set; }

        [JsonPropertyName("leading_whitespace")]
        public long LeadingWhitespace { get; set; }

        [JsonPropertyName("trailing_whitespace")]
        public long TrailingWhitespace { get; set; }

        [JsonPropertyName("different_number_of_email_address")]
        public long DifferentNumberOfEmailAddress { get; set; }

        [JsonPropertyName("different_email_address")]
        public long DifferentEmailAddress { get; set; }

        [JsonPropertyName("different_brackets")]
        public long DifferentBrackets { get; set; }

        [JsonPropertyName("different_numbers")]
        public long DifferentNumbers { get; set; }

        [JsonPropertyName("double_space")]
        public long DoubleSpace { get; set; }

        [JsonPropertyName("special_placeholder")]
        public long SpecialPlaceholder { get; set; }

        [JsonPropertyName("unbalanced_brackets")]
        public long UnbalancedBrackets { get; set; }
    }
}
