using Lokalise.Api.Collections.Projects.Responses;
using Lokalise.Api.Extensions;
using System;

namespace Lokalise.Api.Models
{
    public class Project
    {
        public string ProjectId { get; }

        public string Name { get; }

        public string Description { get; }

        public DateTime CreatedAt { get; }

        public long CreatedBy { get; }

        public string CreatedByEmail { get; }

        public long TeamId { get; }

        public long BaseLanguageId { get; }

        public string BaseLanguageIso { get; }

        public ProjectSettings Settings { get; }

        public ProjectStatistics Statistics { get; }

        internal Project(ProjectResponse response)
        {
            ProjectId = response.ProjectId;
            Name = response.Name;
            Description = response.Description;
            CreatedAt = response.CreatedAtTimestamp.ToUtcDateTime();
            CreatedBy = response.CreatedBy;
            CreatedByEmail = response.CreatedByEmail;
            TeamId = response.TeamId;
            BaseLanguageId = response.BaseLanguageId;
            BaseLanguageIso = response.BaseLanguageIso;
            Settings = response.Settings is object ? new ProjectSettings(response.Settings) : null;
            Statistics = response.Statistics is object ? new ProjectStatistics(response.Statistics) : null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
