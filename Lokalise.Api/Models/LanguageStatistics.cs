using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class LanguageStatistics
    {
        [JsonPropertyName("language_id")]
        public long LanguageId { get; set; }

        [JsonPropertyName("language_iso")]
        public string LanguageIso { get; set; }

        [JsonPropertyName("progress")]
        public short Progress { get; set; }

        [JsonPropertyName("words_to_do")]
        public int WordsToDo { get; set; }

        public override string ToString()
        {
            return LanguageIso;
        }
    }
}
