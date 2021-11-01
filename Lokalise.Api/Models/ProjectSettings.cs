using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class ProjectSettings
    {
        [JsonPropertyName("per_platform_key_names")]
        public bool PerPlatformKeyNames { get; set; }

        [JsonPropertyName("reviewing")]
        public bool Reviewing { get; set; }

        [JsonPropertyName("upvoting")]
        public bool Upvoting { get; set; }

        [JsonPropertyName("auto_toggle_unverified")]
        public bool AutoToggleUnverified { get; set; }

        [JsonPropertyName("offline_translation")]
        public bool OfflineTranslation { get; set; }

        [JsonPropertyName("key_editing")]
        public bool KeyEditing { get; set; }

        [JsonPropertyName("inline_machine_translations")]
        public bool InlineMachineTranslations { get; set; }

        [JsonPropertyName("branching")]
        public bool Brancing { get; set; }

        [JsonPropertyName("custom_translation_Statuses")]
        public bool CustomTranslationStatuses { get; set; }

        [JsonPropertyName("custom_translation_statuses_allow_multiple")]
        public bool CustomTranslationStatusesAllowMultiple { get; set; }
    }
}
