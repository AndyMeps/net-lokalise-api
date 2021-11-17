using Lokalise.Api.Configurations;
using Lokalise.Api.Extensions;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Lokalise.Api.Collections.Keys.Configurations
{

    public class ListKeysConfiguration : PagedConfiguration
    {
        public string Branch { get; set; }

        /// <summary>
        /// Whether to disable key references.
        /// </summary>
        public bool? DisableReferences { get; set; }

        /// <summary>
        /// Whether to include comments.
        /// </summary>
        public bool? IncludeComments { get; set; }

        /// <summary>
        /// Whether to include URL to screenshots. Possible values are 1 and 0.
        /// </summary>
        public bool? IncludeScreenshots { get; set; }

        /// <summary>
        /// Whether to include translations. Possible values are 1 and 0.
        /// </summary>
        public bool? IncludeTranslations { get; set; }

        /// <summary>
        /// One or more language ID to filter by.
        /// </summary>
        public List<long> FilterTranslationLangIds { get; set; } = new List<long>();

        /// <summary>
        /// One or more tags to filter by.
        /// </summary>
        public List<string> FilterTags { get; set; } = new List<string>();

        /// <summary>
        /// One or more filenames to filter by.
        /// </summary>
        public List<string> FilterFilenames { get; set; } = new List<string>();

        /// <summary>
        /// One or more key name to filter by. In case "Per-platform keys" is enabled in project settings, the filter will be applied to all platform names.
        /// </summary>
        public List<string> FilterKeys { get; set; } = new List<string>();

        /// <summary>
        /// One or more key identifiers to filter by.
        /// </summary>
        public List<long> FilterKeyIds { get; set; } = new List<long>();

        /// <summary>
        /// One or more platforms to filter by. Possible values are ios, android, web and other.
        /// </summary>
        public List<string> FilterPlatforms { get; set; } = new List<string>();

        /// <summary>
        /// Filter by untranslated keys.
        /// </summary>
        public bool? FilterUntranslated { get; set; }

        /// <summary>
        /// One or more QA issues to filter by. Possible values are spelling_and_grammar, placeholders, html, url_count, url, email_count, email, brackets, numbers, leading_whitespace, trailing_whitespace, double_space, special_placeholder and unbalanced_brackets.
        /// </summary>
        public List<string> FilterQaIssues { get; set; }

        /// <summary>
        /// One archived filter. Possible values are include, exclude and only.
        /// </summary>
        public string FilterArchived { get; set; }

        internal ListKeysConfiguration()
        {

        }

        internal override string ToQueryString()
        {
            var nameValueCollection = new NameValueCollection();

            AddPagedQueryStringParameters(nameValueCollection);

            if (DisableReferences.HasValue)
                nameValueCollection.Add("disable_references", DisableReferences.Value ? "1" : "0");

            if (IncludeComments.HasValue)
                nameValueCollection.Add("include_comments", IncludeComments.Value ? "1" : "0");

            if (IncludeScreenshots.HasValue)
                nameValueCollection.Add("include_screenshots", IncludeScreenshots.Value ? "1" : "0");

            if (IncludeTranslations.HasValue)
                nameValueCollection.Add("include_translations", IncludeTranslations.Value ? "1" : "0");

            if (FilterTranslationLangIds is object && FilterTranslationLangIds.Count > 0)
                nameValueCollection.Add("filter_translation_lang_ids", string.Join(',', FilterTranslationLangIds));

            if (FilterTags is object && FilterTags.Count > 0)
                nameValueCollection.Add("filter_tags", string.Join(',', FilterTags));

            if (FilterFilenames is object && FilterFilenames.Count > 0)
                nameValueCollection.Add("filter_filesnames", string.Join(',', FilterFilenames));

            if (FilterKeys is object && FilterKeys.Count > 0)
                nameValueCollection.Add("filter_keys", string.Join(',', FilterKeys));

            if (FilterKeyIds is object && FilterKeyIds.Count > 0)
                nameValueCollection.Add("filter_key_ids", string.Join(',', FilterKeyIds));

            if (FilterPlatforms is object && FilterPlatforms.Count > 0)
                nameValueCollection.Add("filter_platforms", string.Join(',', FilterPlatforms));

            if (FilterUntranslated.HasValue)
                nameValueCollection.Add("filter_untranslated", FilterUntranslated.Value ? "1" : "0");

            if (FilterQaIssues is object && FilterQaIssues.Count > 0)
                nameValueCollection.Add("filter_qa_issues", string.Join(',', FilterQaIssues));

            if (!string.IsNullOrWhiteSpace(FilterArchived))
                nameValueCollection.Add("filter_archived", FilterArchived);

            return nameValueCollection.ToQueryString();
        }
    }
}
