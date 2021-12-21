using System.Collections.Generic;
using System.Text.Json.Serialization;
using Lokalise.Api.Collections.Files.Configurations;

namespace Lokalise.Api.Collections.Files.Requests
{
    internal class DownloadFileRequest
    {
        internal DownloadFileRequest(string format, DownloadFileConfiguration options)
        {
            Format = format;
            OriginalFilenames = options?.OriginalFilenames ?? true;
            BundleStructure = options?.BundleStructure;
            DirectoryPrefix = options?.DirectoryPrefix;
            AllPlatforms = options?.AllPlatforms;
            FilterLanguages = options?.FilterLanguages;
            FilterData = options?.FilterData;
            FilterFilenames = options?.FilterFilenames;
            AddNewlineEof = options?.AddNewlineEof;
            CustomTranslationStatusIds = options?.CustomTranslationStatusIds;
            IncludeTags = options?.IncludeTags;
            ExcludeTags = options?.ExcludeTags;
            ExportSort = options?.ExportSort;
            ExportEmptyAs = options?.ExportEmptyAs;
            ExportNullAs = options?.ExportNullAs;
            IncludeComments = options?.IncludeComments;
            IncludeDescription = options?.IncludeDescription;
            IncludeProjectIds = options?.IncludeProjectIds;
            Triggers = options?.Triggers;
            FilterRepositories = options?.FilterRepositories;
            ReplaceBreaks = options?.ReplaceBreaks;
            DisableReferences = options?.DisableReferences;
            PluralFormat = options?.PluralFormat;
            PlaceholderFormat = options?.PlaceholderFormat;
            WebhookUrl = options?.WebhookUrl;
            LanguageMapping = options?.LanguageMapping != null ? new LanguageMappingDto(options.LanguageMapping) : null;
            IcuNumeric = options?.IcuNumeric;
            EscapePercent = options?.EscapePercent;
            Indentation = options?.Indentation;
            YamlIncludeRoot = options?.YamlIncludeRoot;
            JsonUnescapedSlashes = options?.JsonUnescapedSlashes;
            JavaPropertiesEncoding = options?.JavaPropertiesEncoding;
            JavaPropertiesSeparator = options?.JavaPropertiesSeparator;
            BundleDescription = options?.BundleDescription;
        }

        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("format")]
        public string? Format { get; set; }

        [JsonPropertyName("original_filenames")]
        public bool? OriginalFilenames { get; set; }

        [JsonPropertyName("bundle_structure")]
        public string? BundleStructure { get; set; }

        [JsonPropertyName("directory_prefix")]
        public string? DirectoryPrefix { get; set; }

        [JsonPropertyName("all_platforms")]
        public bool? AllPlatforms { get; set; }

        [JsonPropertyName("filter_langs")]
        public IEnumerable<string>? FilterLanguages { get; set; }

        [JsonPropertyName("filter_data")]
        public IEnumerable<string>? FilterData { get; set; }

        [JsonPropertyName("filter_filenames")]
        public IEnumerable<string>? FilterFilenames { get; set; }

        [JsonPropertyName("add_newline_eof")]
        public bool? AddNewlineEof { get; set; }

        [JsonPropertyName("custom_translation_status_ids")]
        public IEnumerable<string>? CustomTranslationStatusIds { get; set; }

        [JsonPropertyName("include_tags")]
        public IEnumerable<string>? IncludeTags { get; set; }

        [JsonPropertyName("exclude_tags")]
        public IEnumerable<string>? ExcludeTags { get; set; }

        [JsonPropertyName("export_sort")]
        public string? ExportSort { get; set; }

        [JsonPropertyName("export_empty_as")]
        public string? ExportEmptyAs { get; set; }

        [JsonPropertyName("export_null_as")]
        public string? ExportNullAs { get; set; }

        [JsonPropertyName("include_comments")]
        public bool? IncludeComments { get; set; }

        [JsonPropertyName("include_description")]
        public bool? IncludeDescription { get; set; }

        [JsonPropertyName("include_project_ids")]
        public IEnumerable<string>? IncludeProjectIds { get; set; }

        [JsonPropertyName("triggers")]
        public IEnumerable<string>? Triggers { get; set; }

        [JsonPropertyName("filter_repositories")]
        public IEnumerable<string>? FilterRepositories { get; set; }

        [JsonPropertyName("replace_breaks")]
        public bool? ReplaceBreaks { get; set; }

        [JsonPropertyName("disable_references")]
        public bool? DisableReferences { get; set; }

        [JsonPropertyName("plural_formats")]
        public string? PluralFormat { get; set; }

        [JsonPropertyName("placeholder_format")]
        public string? PlaceholderFormat { get; set; }

        [JsonPropertyName("webhook_url")]
        public string? WebhookUrl { get; set; }

        [JsonPropertyName("language_mapping")]
        public LanguageMappingDto? LanguageMapping { get; set; }

        [JsonPropertyName("icu_numeric")]
        public bool? IcuNumeric { get; set; }

        [JsonPropertyName("escape_percent")]
        public bool? EscapePercent { get; set; }

        [JsonPropertyName("indentation")]
        public string? Indentation { get; set; }

        [JsonPropertyName("yaml_include_root")]
        public bool? YamlIncludeRoot { get; set; }

        [JsonPropertyName("json_unescaped_slashes")]
        public bool? JsonUnescapedSlashes { get; set; }

        [JsonPropertyName("java_properties_encoding")]
        public string? JavaPropertiesEncoding { get; set; }

        [JsonPropertyName("java_properties_separator")]
        public string? JavaPropertiesSeparator { get; set; }

        [JsonPropertyName("bundle_description")]
        public string? BundleDescription { get; set; }
    }
}