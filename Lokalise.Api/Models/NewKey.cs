using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class NewKey
    {
        /// <summary>
        /// Key identifier. For projects with enabled Per-platform key names, pass JSON encoded string with included ios, android, web and other string attributes.
        /// </summary>
        [JsonPropertyName("key_name")]
        public string? KeyName { get; }

        /// <summary>
        /// Description of the key.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; }

        /// <summary>
        /// List of platforms, enabled for this key. Possible values are ios, android, web and other.
        /// </summary>
        [JsonPropertyName("platforms")]
        public IEnumerable<string>? Platforms { get; }

        /// <summary>
        /// An object containing key filename attribute for each platform.
        /// </summary>
        [JsonPropertyName("filenames")]
        public FileNames? Filenames { get; }

        /// <summary>
        /// List of tags for this keys.
        /// </summary>
        [JsonPropertyName("tags")]
        public IEnumerable<string>? Tags { get; }

        /// <summary>
        /// List of comments for this key.
        /// </summary>
        [JsonPropertyName("comments")]
        public IEnumerable<string>? Comments { get; }

        /// <summary>
        /// List of screenshots, attached to this key.
        /// </summary>
        [JsonPropertyName("screenshots")]
        public IEnumerable<NewScreenshot>? Screenshots { get; }

        /// <summary>
        /// Translations for all languages.
        /// </summary>
        [JsonPropertyName("translations")]
        public IEnumerable<NewTranslation>? Translations { get; }

        /// <summary>
        /// Whether this key is plural.
        /// </summary>
        [JsonPropertyName("is_plural")]
        public bool? IsPlural { get; }

        /// <summary>
        /// Optional custom plural name (used in some formats).
        /// </summary>
        [JsonPropertyName("plural_name")]
        public string? PluralName { get; }

        /// <summary>
        /// Whether this key is hidden from non-admins (translators).
        /// </summary>
        [JsonPropertyName("is_hidden")]
        public bool? IsHidden { get; }

        /// <summary>
        /// Whether this key is archived.
        /// </summary>
        [JsonPropertyName("is_archived")]
        public bool? IsArchived { get; }

        /// <summary>
        /// Optional context of the key (used with some file formats).
        /// </summary>
        [JsonPropertyName("context")]
        public string? Context { get; }

        /// <summary>
        /// Maximum allowed number of characters in translations for this key.
        /// </summary>
        [JsonPropertyName("char_limit")]
        public long? CharLimit { get; }

        /// <summary>
        /// JSON encoded string containing custom attributes (if any).
        /// </summary>~
        [JsonPropertyName("custom_attributes")]
        public string? CustomAttributes { get; }

        public NewKey(
            string keyName,
            IEnumerable<string> platforms,
            string? description = null,
            FileNames? filenames = null,
            IEnumerable<string>? tags = null,
            IEnumerable<string>? comments = null,
            IEnumerable<NewScreenshot>? screenshots = null,
            IEnumerable<NewTranslation>? translations = null,
            bool? isPlural = null,
            string? pluralName = null,
            bool? isHidden = null,
            bool? isArchived = null,
            string? context = null,
            long? charLimit = null,
            string? customAttributes = null)
        {
            KeyName = keyName;
            Platforms = platforms;
            Description = description;
            Filenames = filenames;
            Tags = tags;
            Comments = comments;
            Screenshots = screenshots;
            Translations = translations;
            IsPlural = isPlural;
            PluralName = pluralName;
            IsHidden = isHidden;
            IsArchived = isArchived;
            Context = context;
            CharLimit = charLimit;
            CustomAttributes = customAttributes;
        }
    }

    public class NewTranslation
    {
        /// <summary>
        /// Unique code of the language of the translation.
        /// </summary>
        [JsonPropertyName("language_iso")]
        public string LanguageIso { get; }

        /// <summary>
        /// The actual translation. Pass as an object, in case it includes plural forms and is_plural is true.
        /// </summary>
        [JsonPropertyName("translation")]
        public string Value { get; }

        /// <summary>
        /// Whether the translation is marked as Reviewed.
        /// </summary>
        [JsonPropertyName("is_reviewed")]
        public bool? IsReviewed { get; }

        /// <summary>
        /// Whether the translation is marked as Unverified.
        /// </summary>
        [JsonPropertyName("is_unverified")]
        public bool? IsUnverified { get; }

        /// <summary>
        /// Custom translation status IDs to assign to translation.
        /// </summary>
        [JsonPropertyName("custom_translation_status_ids")]
        public IEnumerable<string>? CustomTranslationStatusIds { get; }

        /// <summary>
        /// Create a new translation object.
        /// </summary>
        /// <param name="languageIso">Unique code of the language of the translation.</param>
        /// <param name="value">The actual translation. Pass as an object, in case it includes plural forms and is_plural is true.</param>
        /// <param name="isReviewed">Whether the translation is marked as Reviewed.</param>
        /// <param name="isUnverified">Whether the translation is marked as Unverified.</param>
        /// <param name="customTranslationStatusIds">Custom translation status IDs to assign to translation.</param>
        public NewTranslation(string languageIso, string value, bool? isReviewed = null, bool? isUnverified = null, IEnumerable<string>? customTranslationStatusIds = null)
        {
            LanguageIso = languageIso;
            Value = value;
            IsReviewed = isReviewed;
            IsUnverified = isUnverified;
            CustomTranslationStatusIds = customTranslationStatusIds;
        }
    }
}
