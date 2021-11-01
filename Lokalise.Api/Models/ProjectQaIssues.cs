using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    /// <summary>
    /// Contains counts for each QA issue type.
    /// </summary>
    public class ProjectQaIssues
    {
        /// <summary>
        /// Count of not reviewed translations.
        /// </summary>
        [JsonPropertyName("not_reviewed")]
        public long NotReviewed { get; set; }

        /// <summary>
        /// Count of unverified translations.
        /// </summary>
        [JsonPropertyName("unverified")]
        public long Unverified { get; set; }

        /// <summary>
        /// Count of translations with spelling and/or grammar errors.
        /// </summary>
        [JsonPropertyName("spelling_grammar")]
        public long SpellingGrammar { get; set; }

        /// <summary>
        /// Count of translations with inconsistent placeholders (source vs target).
        /// </summary>
        [JsonPropertyName("inconsistent_placeholders")]
        public long InconsistentPlaceholders { get; set; }

        /// <summary>
        /// Count of translations with inconsistent HTML tags (source vs target).
        /// </summary>
        [JsonPropertyName("inconsistent_html")]
        public long InconsistentHtml { get; set; }

        /// <summary>
        /// Count of translations with different number of URLs (source vs target).
        /// </summary>
        [JsonPropertyName("different_number_of_urls")]
        public long DifferentNumberOfUrls { get; set; }

        /// <summary>
        /// Count of translations with different URLs (source vs target).
        /// </summary>
        [JsonPropertyName("different_urls")]
        public long DifferentUrls { get; set; }

        /// <summary>
        /// Count of translations with leading whitespace.
        /// </summary>
        [JsonPropertyName("leading_whitespace")]
        public long LeadingWhitespace { get; set; }

        /// <summary>
        /// Count of translations with trailing whitespace.
        /// </summary>
        [JsonPropertyName("trailing_whitespace")]
        public long TrailingWhitespace { get; set; }

        /// <summary>
        /// Count of translations with different number of email address (source vs target).
        /// </summary>
        [JsonPropertyName("different_number_of_email_address")]
        public long DifferentNumberOfEmailAddress { get; set; }

        /// <summary>
        /// Count of translations with different email address (source vs target).
        /// </summary>
        [JsonPropertyName("different_email_address")]
        public long DifferentEmailAddress { get; set; }

        /// <summary>
        /// Count of translations with different brackets (source vs target).
        /// </summary>
        [JsonPropertyName("different_brackets")]
        public long DifferentBrackets { get; set; }

        /// <summary>
        /// Count of translations with different numbers (source vs target).
        /// </summary>
        [JsonPropertyName("different_numbers")]
        public long DifferentNumbers { get; set; }

        /// <summary>
        /// Count of translations with double spaces (target).
        /// </summary>
        [JsonPropertyName("double_space")]
        public long DoubleSpace { get; set; }

        /// <summary>
        /// Count of invalid use of [VOID], [TRUE], [FALSE] placeholders (target).
        /// </summary>
        [JsonPropertyName("special_placeholder")]
        public long SpecialPlaceholder { get; set; }

        /// <summary>
        /// Count of unbalanced brackets (target).
        /// </summary>
        [JsonPropertyName("unbalanced_brackets")]
        public long UnbalancedBrackets { get; set; }
    }
}
