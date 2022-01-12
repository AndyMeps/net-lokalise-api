using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class Translation
    {
        /// <summary>
        /// Unique identifier of translation entry.
        /// </summary>
        [JsonPropertyName("translation_id")]
        public long? TranslationId { get; set; }

        /// <summary>
        /// A unique identifier of the key.
        /// </summary>
        [JsonPropertyName("key_id")]
        public long? KeyId { get; set; }

        /// <summary>
        /// Unique code of the language of the translation.
        /// </summary>
        [JsonPropertyName("language_iso")]
        public string? LanguageIso { get; set; }

        /// <summary>
        /// The actual translation. Pass as an object, in case it includes plural forms and is_plural is true.
        /// </summary>
        [JsonPropertyName("translation")]
        public string? Value { get; set; }

        /// <summary>
        /// Identifier of a user, who has updated the translation.
        /// </summary>
        [JsonPropertyName("modified_by")]
        public long? ModifiedBy { get; set; }

        /// <summary>
        /// E-mail of a user, who has updated the translation.
        /// </summary>
        [JsonPropertyName("modified_by_email")]
        public string? ModifiedByEmail { get; set; }

        /// <summary>
        /// Date of last modification of the translation.
        /// </summary>
        [JsonPropertyName("modified_at")]
        public string? ModifiedAt { get; set; }

        /// <summary>
        /// Date of last modification of the translation as a unix timestamp.
        /// </summary>
        [JsonPropertyName("modified_at_timestamp")]
        public long? ModifiedAtTimestamp { get; set; }

        /// <summary>
        /// Whether the translation is marked as Reviewed.
        /// </summary>
        [JsonPropertyName("is_reviewed")]
        public bool? IsReviewed { get; set; }

        /// <summary>
        /// Whether the translation is marked as Unverified.
        /// </summary>
        [JsonPropertyName("is_unverified")]
        public bool? IsUnverified { get; set; }

        /// <summary>
        /// Identifier of the user, who has reviewed the translation (if reviewed).
        /// </summary>
        [JsonPropertyName("reviewed_by")]
        public long? ReviewedBy { get; set; }

        /// <summary>
        /// Number of words in the translation.
        /// </summary>
        [JsonPropertyName("words")]
        public long? Words { get; set; }

        /// <summary>
        /// Array consisting of Custom Translation Status objects.
        /// </summary>
        [JsonPropertyName("custom_translation_statuses")]
        public IEnumerable<CustomTranslationStatus>? CustomTranslationStatuses { get; set; }

        /// <summary>
        /// Identifier of the task, if the key is a part of one, or null if it's not.
        /// </summary>
        [JsonPropertyName("task_id")]
        public long? TaskId { get; set; }
    }
}
