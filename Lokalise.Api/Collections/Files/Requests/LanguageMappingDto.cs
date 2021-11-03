using System.Text.Json.Serialization;
using Lokalise.Api.Collections.Files.Configurations;

namespace Lokalise.Api.Collections.Files.Requests
{
    internal class LanguageMappingDto
    {
        [JsonPropertyName("original_language_iso")]
        public string OriginalLanguageIso { get; }

        [JsonPropertyName("custom_language_iso")]
        public string CustomLanguageIso { get; }

        internal LanguageMappingDto(LanguageMapping languageMapping)
        {
            OriginalLanguageIso = languageMapping.OriginalLanguageIso;
            CustomLanguageIso = languageMapping.CustomLanguageIso;
        }
    }
}