using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Projects.Responses
{
    internal class LanguageStatisticsResponse
    {
        [JsonPropertyName("language_id")]
        public long LanguageId { get; set; }

        [JsonPropertyName("language_iso")]
        public string LanguageIso { get; set; }

        [JsonPropertyName("progress")]
        public long Progress { get; set; }

        [JsonPropertyName("words_to_do")]
        public long WordsToDo { get; set; }
    }
}
