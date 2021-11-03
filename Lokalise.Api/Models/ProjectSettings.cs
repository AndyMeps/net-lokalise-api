using Lokalise.Api.Collections.Projects.Responses;

namespace Lokalise.Api.Models
{
    public class ProjectSettings
    {
        public bool PerPlatformKeyNames { get; }

        public bool Reviewing { get; }

        public bool Upvoting { get; }

        public bool AutoToggleUnverified { get; }

        public bool OfflineTranslation { get; }

        public bool KeyEditing { get; }

        public bool InlineMachineTranslations { get; }

        public bool Branching { get; }

        public bool CustomTranslationStatuses { get; }

        public bool CustomTranslationStatusesAllowMultiple { get; }

        internal ProjectSettings(ProjectSettingsResponse response)
        {
            PerPlatformKeyNames = response.PerPlatformKeyNames;
            Reviewing = response.Reviewing;
            Upvoting = response.Upvoting;
            AutoToggleUnverified = response.AutoToggleUnverified;
            OfflineTranslation = response.OfflineTranslation;
            KeyEditing = response.KeyEditing;
            InlineMachineTranslations = response.InlineMachineTranslations;
            Branching = response.Branching;
            CustomTranslationStatuses = response.CustomTranslationStatuses;
            CustomTranslationStatusesAllowMultiple = response.CustomTranslationStatusesAllowMultiple;
        }
    }
}
