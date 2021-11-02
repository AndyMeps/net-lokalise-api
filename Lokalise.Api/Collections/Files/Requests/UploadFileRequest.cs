using System.Collections.Generic;
using System.Text.Json.Serialization;
using Lokalise.Api.Collections.Files.Configurations;

namespace Lokalise.Api.Collections.Files.Requests
{
    internal class UploadFileRequest
    {
        internal UploadFileRequest(string data, string filename, string langIso, UploadFileConfiguration options)
        {
            Data = data;
            Filename = filename;
            LangIso = langIso;
            ConvertPlaceholders = options?.ConvertPlaceholders;
            Tags = options?.Tags;
            TagInsertedKeys = options?.TagInsertedKeys;
            TagUpdatedKeys = options?.TagUpdatedKeys;
            TagSkippedKeys = options?.TagSkippedKeys;
            ReplaceModified = options?.ReplaceModified;
            SlashNToLinebreak = options?.SlashNToLinebreak;
            KeysToValues = options?.KeysToValues;
            DistinguishByFile = options?.DistinguishByFile;
            ApplyTranslationMemory = options?.ApplyTranslationMemory;
            UseAutomations = options?.UseAutomations;
            HiddenFromContributors = options?.HiddenFromContributors;
            CleanupMode = options?.CleanupMode;
            CustomTranslationStatusIds = options?.CustomTranslationStatusIds;
            CustomTranslationStatusInsertedKeys = options?.CustomTranslationStatusInsertedKeys;
            CustomTranslationStatusUpdatedKeys = options?.CustomTranslationStatusUpdatedKeys;
            CustomTranslationStatusSkippedKeys = options?.CustomTranslationStatusSkippedKeys;
            SkipDetectLangIso = options?.SkipDetectLangIso;
        }

        [JsonPropertyName("data")]
        public string Data { get; internal set; }

        [JsonPropertyName("filename")]
        public string Filename { get; internal set; }

        [JsonPropertyName("lang_iso")]
        public string LangIso { get; internal set; }

        [JsonPropertyName("convert_placeholders")]
        public bool? ConvertPlaceholders { get; set; }

        [JsonPropertyName("detect_icu_plurals")]
        public bool? DetectIcuPlurals { get; set; }

        [JsonPropertyName("tags")]
        public ICollection<string> Tags { get; set; }

        [JsonPropertyName("tag_inserted_keys")]
        public bool? TagInsertedKeys { get; set; }

        [JsonPropertyName("tag_updated_keys")]
        public bool? TagUpdatedKeys { get; set; }

        [JsonPropertyName("tag_skipped_keys")]
        public bool? TagSkippedKeys { get; set; }

        [JsonPropertyName("replace_modified")]
        public bool? ReplaceModified { get; set; }

        [JsonPropertyName("slashn_to_linebreak")]
        public bool? SlashNToLinebreak { get; set; }

        [JsonPropertyName("keys_to_values")]
        public bool? KeysToValues { get; set; }

        [JsonPropertyName("distinguish_by_file")]
        public bool? DistinguishByFile { get; set; }

        [JsonPropertyName("apply_tm")]
        public bool? ApplyTranslationMemory { get; set; }

        [JsonPropertyName("use_automations")]
        public bool? UseAutomations { get; set; }

        [JsonPropertyName("hidden_from_contributors")]
        public bool? HiddenFromContributors { get; set; }

        [JsonPropertyName("cleanup_mode")]
        public bool? CleanupMode { get; set; }

        [JsonPropertyName("custom_translation_status_ids")]
        public ICollection<string> CustomTranslationStatusIds { get; set; } // TODO: Check this type

        [JsonPropertyName("custom_translation_status_inserted_keys")]
        public bool? CustomTranslationStatusInsertedKeys { get; set; }

        [JsonPropertyName("custom_translation_status_updted_keys")]
        public bool? CustomTranslationStatusUpdatedKeys { get; set; }

        [JsonPropertyName("custom_translation_status_skipped_keys")]
        public bool? CustomTranslationStatusSkippedKeys { get; set; }

        [JsonPropertyName("skip_detect_lang_iso")]
        public bool? SkipDetectLangIso { get; set; }
    }
}
