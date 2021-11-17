using System;
using System.Collections.Generic;

namespace Lokalise.Api.Models
{
    public class Translation
    {
        /// <summary>
        /// Unique identifier of translation entry.
        /// </summary>
        public long TranslationId { get; }

        /// <summary>
        /// A unique identifier of the key.
        /// </summary>
        public long KeyId { get; }

        /// <summary>
        /// Unique code of the language of the translation.
        /// </summary>
        public string LanguageIso { get; }

        /// <summary>
        /// The actual translation. Pass as an object, in case it includes plural forms and is_plural is true.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Identifier of a user, who has updated the translation.
        /// </summary>
        public long? ModifiedBy { get; }

        /// <summary>
        /// E-mail of a user, who has updated the translation.
        /// </summary>
        public string ModifiedByEmail { get; }

        /// <summary>
        /// Date of last modification of the translation.
        /// </summary>
        public DateTime? ModifiedAt { get; }

        /// <summary>
        /// Whether the translation is marked as Reviewed.
        /// </summary>
        public bool IsReviewed { get; }

        /// <summary>
        /// Whether the translation is marked as Unverified.
        /// </summary>
        public bool IsUnverified { get; }

        /// <summary>
        /// Identifier of the user, who has reviewed the translation (if reviewed).
        /// </summary>
        public long ReviewedBy { get; }

        /// <summary>
        /// Number of words in the translation.
        /// </summary>
        public long Words { get; }

        /// <summary>
        /// Array consisting of Custom Translation Status objects.
        /// </summary>
        public IEnumerable<CustomTranslationStatus> CustomTranslationStatuses { get; }

        /// <summary>
        /// Identifier of the task, if the key is a part of one, or null if it's not.
        /// </summary>
        public long? TaskId { get; }
    }
}
