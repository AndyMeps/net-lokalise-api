using System.Collections.Generic;

namespace Lokalise.Api.Collections.Files.Configurations
{
    public class UploadFileConfiguration
    {
        public string Branch { get; set; }

        public bool? ConvertPlaceholders { get; set; }

        public bool? DetectIcuPlurals { get; set; }

        public ICollection<string> Tags { get; set; }

        public bool? TagInsertedKeys { get; set; }
        public bool? TagUpdatedKeys { get; set; }
        public bool? TagSkippedKeys { get; set; }
        public bool? ReplaceModified { get; set; }
        public bool? SlashNToLinebreak { get; set; }
        public bool? KeysToValues { get; set; }
        public bool? DistinguishByFile { get; set; }
        public bool? ApplyTranslationMemory { get; set; }
        public bool? UseAutomations { get; set; }
        public bool? HiddenFromContributors { get; set; }
        public bool? CleanupMode { get; set; }
        public ICollection<string> CustomTranslationStatusIds { get; set; } // TODO: Check this type
        public bool? CustomTranslationStatusInsertedKeys { get; set; }
        public bool? CustomTranslationStatusUpdatedKeys { get; set; }
        public bool? CustomTranslationStatusSkippedKeys { get; set; }
        public bool? SkipDetectLangIso { get; set; }
    }
}
