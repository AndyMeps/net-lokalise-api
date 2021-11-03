using Lokalise.Api.Collections.Projects.Responses;

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
        public long NotReviewed { get; }

        /// <summary>
        /// Count of unverified translations.
        /// </summary>
        public long Unverified { get; }

        /// <summary>
        /// Count of translations with spelling and/or grammar errors.
        /// </summary>
        public long SpellingGrammar { get; }

        /// <summary>
        /// Count of translations with inconsistent placeholders (source vs target).
        /// </summary>
        public long InconsistentPlaceholders { get; }

        /// <summary>
        /// Count of translations with inconsistent HTML tags (source vs target).
        /// </summary>
        public long InconsistentHtml { get; }

        /// <summary>
        /// Count of translations with different number of URLs (source vs target).
        /// </summary>
        public long DifferentNumberOfUrls { get; }

        /// <summary>
        /// Count of translations with different URLs (source vs target).
        /// </summary>
        public long DifferentUrls { get; }

        /// <summary>
        /// Count of translations with leading whitespace.
        /// </summary>
        public long LeadingWhitespace { get; }

        /// <summary>
        /// Count of translations with trailing whitespace.
        /// </summary>
        public long TrailingWhitespace { get; }

        /// <summary>
        /// Count of translations with different number of email address (source vs target).
        /// </summary>
        public long DifferentNumberOfEmailAddress { get; }

        /// <summary>
        /// Count of translations with different email address (source vs target).
        /// </summary>
        public long DifferentEmailAddress { get; }

        /// <summary>
        /// Count of translations with different brackets (source vs target).
        /// </summary>
        public long DifferentBrackets { get; }

        /// <summary>
        /// Count of translations with different numbers (source vs target).
        /// </summary>
        public long DifferentNumbers { get; }

        /// <summary>
        /// Count of translations with double spaces (target).
        /// </summary>
        public long DoubleSpace { get; }

        /// <summary>
        /// Count of invalid use of [VOID], [TRUE], [FALSE] placeholders (target).
        /// </summary>
        public long SpecialPlaceholder { get; }

        /// <summary>
        /// Count of unbalanced brackets (target).
        /// </summary>
        public long UnbalancedBrackets { get; }

        internal ProjectQaIssues(ProjectQaIssuesResponse response)
        {
            NotReviewed = response.NotReviewed;
            Unverified = response.Unverified;
            SpellingGrammar = response.SpellingGrammar;
            InconsistentPlaceholders = response.InconsistentPlaceholders;
            InconsistentHtml = response.InconsistentHtml;
            DifferentNumberOfUrls = response.DifferentNumberOfUrls;
            DifferentUrls = response.DifferentUrls;
            LeadingWhitespace = response.LeadingWhitespace;
            TrailingWhitespace = response.TrailingWhitespace;
            DifferentNumberOfEmailAddress = response.DifferentNumberOfEmailAddress;
            DifferentEmailAddress = response.DifferentEmailAddress;
            DifferentBrackets = response.DifferentBrackets;
            DifferentNumbers = response.DifferentNumbers;
            DoubleSpace = response.DoubleSpace;
            SpecialPlaceholder = response.SpecialPlaceholder;
            UnbalancedBrackets = response.UnbalancedBrackets;
        }
    }
}
