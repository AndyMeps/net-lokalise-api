using Lokalise.Api.Collections.Projects.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Lokalise.Api.Models
{
    public class ProjectStatistics
    {
        public short ProgressTotal { get; }

        public long KeysTotal { get; }

        public long Team { get; }

        public long BaseWords { get; }

        public long QaIssuesTotal { get; }

        public ProjectQaIssues QaIssues { get; }

        public IEnumerable<LanguageStatistics> Languages { get; }

        internal ProjectStatistics(ProjectStatisticsResponse response)
        {
            ProgressTotal = response.ProgressTotal;
            KeysTotal = response.KeysTotal;
            Team = response.Team;
            BaseWords = response.BaseWords;
            QaIssuesTotal = response.QaIssuesTotal;
            QaIssues = response.QaIssues is object ? new ProjectQaIssues(response.QaIssues) : null;
            Languages = response.Languages is object ? response.Languages.Select(l => new LanguageStatistics(l)) : null;
        }
    }
}
