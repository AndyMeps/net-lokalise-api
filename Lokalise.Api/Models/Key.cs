using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class Key
    {
        [JsonPropertyName("key_id")]
        public long KeyId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("key_name")]
        public KeyNames KeyName { get; set; }

        [JsonPropertyName("filenames")]
        public FileNames Filenames { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("platforms")]
        public IEnumerable<string> Platforms { get; set; }

        [JsonPropertyName("keys")]
        public IEnumerable<string> Keys { get; set; }

        [JsonPropertyName("comments")]
        public IEnumerable<Comment> Comments { get; set; }

        //[JsonPropertyName("screenshots")]
        //public IEnumerable<ScreenshotResponse> Screenshots { get; set; }

        //[JsonPropertyName("translations")]
        //public IEnumerable<TranslationResponse> Translations { get; set; }

        [JsonPropertyName("is_plural")]
        public bool IsPlural { get; set; }

        [JsonPropertyName("plural_name")]
        public string PluralName { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("is_archived")]
        public bool IsArchived { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("base_words")]
        public long BaseWords { get; set; }

        [JsonPropertyName("char_limit")]
        public long? CharLimit { get; set; }

        [JsonPropertyName("custom_attributes")]
        public string CustomAttributes { get; set; }

        [JsonPropertyName("modified_at")]
        public string ModifiedAt { get; set; }

        [JsonPropertyName("modified_at_timestamp")]
        public long? ModifiedAtTimestamp { get; set; }

        [JsonPropertyName("translations_modified_at")]
        public string TranslationsModifiedAt { get; set; }

        [JsonPropertyName("translations_modified_at_timestamp")]
        public long? TranslationsModifiedAtTimestamp { get; set; }
    }
}
