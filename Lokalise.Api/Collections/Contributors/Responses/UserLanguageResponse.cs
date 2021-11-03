using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Responses
{
    internal class UserLanguageResponse
    {
        [JsonPropertyName("language_id")]
        public long LanguageId { get; set; }

        [JsonPropertyName("language_iso")]
        public string LanguageIso { get; set; }

        [JsonPropertyName("language_name")]
        public string LanguageName { get; set; }

        [JsonPropertyName("is_writable")]
        public bool IsWritable { get; set; }
    }
}
