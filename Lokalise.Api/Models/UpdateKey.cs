using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class UpdateKey
    {
        /// <summary>
        /// Key identifier. For projects with enabled Per-platform key names, pass JSON encoded string with included ios, android, web and other string attributes.
        /// </summary>
        [JsonPropertyName("key_id")]
        public long? KeyId { get; }

        /// <summary>
        /// Name of the key.
        /// </summary>
        [JsonPropertyName("key_name")]
        public string? KeyName { get; set; }

        /// <summary>
        /// Description of the key.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// List of platforms, enabled for this key. Possible values are ios, android, web and other.
        /// </summary>
        [JsonPropertyName("platforms")]
        public IEnumerable<string>? Platforms { get; set; }

        /// <summary>
        /// An object containing key filename attribute for each platform.
        /// </summary>
        [JsonPropertyName("filenames")]
        public FileNames? Filenames { get; set; }

        /// <summary>
        /// List of tags for this keys.
        /// </summary>
        [JsonPropertyName("tags")]
        public IEnumerable<string>? Tags { get; set; }

        /// <summary>
        /// Enable to merge specified tags with the current tags attached to the key.
        /// </summary>
        [JsonPropertyName("merge_tags")]
        public bool? MergeTags { get; set; }

        /// <summary>
        /// Whether this key is plural.
        /// </summary>
        [JsonPropertyName("is_plural")]
        public bool? IsPlural { get; set; }

        /// <summary>
        /// Optional custom plural name (used in some formats).
        /// </summary>
        [JsonPropertyName("plural_name")]
        public string? PluralName { get; set; }

        /// <summary>
        /// Whether this key is hidden from non-admins (translators).
        /// </summary>
        [JsonPropertyName("is_hidden")]
        public bool? IsHidden { get; set; }

        /// <summary>
        /// Whether this key is archived.
        /// </summary>
        [JsonPropertyName("is_archived")]
        public bool? IsArchived { get; set; }

        /// <summary>
        /// Optional context of the key (used with some file formats).
        /// </summary>
        [JsonPropertyName("context")]
        public string? Context { get; set; }

        /// <summary>
        /// Maximum allowed number of characters in translations for this key.
        /// </summary>
        [JsonPropertyName("char_limit")]
        public long? CharLimit { get; set; }

        /// <summary>
        /// JSON encoded string containing custom attributes (if any).
        /// </summary>
        [JsonPropertyName("custom_attributes")]
        public string? CustomAttributes { get; set; }

        public UpdateKey(long keyId)
        {
            KeyId = keyId;
        }
    }
}
