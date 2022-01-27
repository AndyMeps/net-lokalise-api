using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class Screenshot
    {
        /// <summary>
        /// A unique identifier of the screenshot.
        /// </summary>
        [JsonPropertyName("screenshot_id")]
        public long ScreenshotId { get; set; }

        /// <summary>
        /// List of key identifiers, the screenshot is attached to.
        /// </summary>
        [JsonPropertyName("key_ids")]
        public IEnumerable<long>? KeyIds { get; set; }

        /// <summary>
        /// Link to the screenshot.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Screenshot title.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Description of the screenshot.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// List of screenshot tags.
        /// </summary>
        [JsonPropertyName("screenshot_tags")]
        public IEnumerable<string>? Tags { get; set; }

        /// <summary>
        /// Width of the screenshot, in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public long? Width { get; set; }

        /// <summary>
        /// Height of the screenshot, in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public long? Height { get; set; }

        /// <summary>
        /// Creation date of the screenshot.
        /// </summary>
        [JsonPropertyName("created_at")]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// Creation date of the screenshot as a unix timestamp.
        /// </summary>
        [JsonPropertyName("created_at_timestamp")]
        public long? CreatedAtTimestamp { get; set; }
    }
}
