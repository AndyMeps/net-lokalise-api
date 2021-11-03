using Lokalise.Api.Models;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Requests
{
    internal class ContributorLanguageRequest
    {
        [JsonPropertyName("lang_iso")]
        public string LanguageIso { get; }

        [JsonPropertyName("is_writable")]
        public bool IsWritable { get; }

        internal ContributorLanguageRequest(ContributorLanguage contributorLanguage)
        {
            LanguageIso = contributorLanguage.LanguageIso;
            IsWritable = contributorLanguage.IsWritable;
        }
    }
}
