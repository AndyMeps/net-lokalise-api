using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class ProjectLanguage
    {
        [JsonPropertyName("lang_iso")]
        public string LangIso { get; }

        [JsonPropertyName("custom_iso")]
        public string? CustomIso { get; }

        public ProjectLanguage(string langIso, string? customIso = null)
        {
            LangIso = langIso;
            CustomIso = customIso;
        }
    }
}