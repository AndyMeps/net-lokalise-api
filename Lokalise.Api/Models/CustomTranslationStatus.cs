using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class CustomTranslationStatus
    {
        /// <summary>
        /// A unique custom translation status identifier.
        /// </summary>
        [JsonPropertyName("status_id")]
        public long? StatusId { get; set; }

        /// <summary>
        /// Status title.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Hex color of the status.
        /// </summary>
        [JsonPropertyName("color")]
        public string? Color { get; set; }
        
    }
}
