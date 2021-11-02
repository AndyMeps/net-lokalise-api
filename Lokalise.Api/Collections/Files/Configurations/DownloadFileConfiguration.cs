using System.Collections.Generic;

namespace Lokalise.Api.Collections.Files.Configurations
{
    public class DownloadFileConfiguration
    {
        public string Branch { get; set; }
        public bool? OriginalFilenames { get; set; }
        public string BundleStructure { get; set; }
        public string DirectoryPrefix { get; set; }
        public bool? AllPlatforms { get; set; }
        public IEnumerable<string> FilterLanguages { get; set; }
        public IEnumerable<string> FilterData { get; set; }
        public IEnumerable<string> FilterFilenames { get; set; }
        public bool? AddNewlineEof { get; set; }
        public IEnumerable<string> CustomTranslationStatusIds { get; set; }
        public IEnumerable<string> IncludeTags { get; set; }
        public IEnumerable<string> ExcludeTags { get; set; }
        public string ExportSort { get; set; }
        public string ExportEmptyAs { get; set; }
        public string ExportNullAs { get; set; }
        public bool? IncludeComments { get; set; }
        public bool? IncludeDescription { get; set; }
        public IEnumerable<string> IncludeProjectIds { get; set; }
        public IEnumerable<string> Triggers { get; set; }
        public IEnumerable<string> FilterRepositories { get; set; }
        public bool? ReplaceBreaks { get; set; }
        public bool? DisableReferences { get; set; }
        public string PluralFormat { get; set; }
        public string PlaceholderFormat { get; set; }
        public string WebhookUrl { get; set; }
        public LanguageMapping LanguageMapping { get; set; }
        public bool? IcuNumeric { get; set; }
        public bool? EscapePercent { get; set; }
        public string Indentation { get; set; }
        public bool? YamlIncludeRoot { get; set; }
        public bool? JsonUnescapedSlashes { get; set; }
        public string JavaPropertiesEncoding { get; set; }
        public string JavaPropertiesSeparator { get; set; }
        public string BundleDescription { get; set; }
    }

    public class LanguageMapping
    {
        public string OriginalLanguageIso { get; set; }
        public string CustomLanguageIso { get; set; }
    }
}