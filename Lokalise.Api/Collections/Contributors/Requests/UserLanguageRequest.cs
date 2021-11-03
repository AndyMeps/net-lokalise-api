using Lokalise.Api.Models;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Requests
{
    internal class UserLanguageRequest
    {
        [JsonPropertyName("lang_iso")]
        public string LanguageIso { get; }

        [JsonPropertyName("is_writable")]
        public bool IsWritable { get; }

        internal UserLanguageRequest(UserLanguage userLanguage)
        {
            LanguageIso = userLanguage.LanguageIso;
            IsWritable = userLanguage.IsWritable;
        }
    }
}
