using System.Collections.Generic;

namespace Lokalise.Api.Models
{
    public class ProjectStatistics
    {
        public short ProgressTotal { get; set; }
        public int KeysTotal { get; set; }
        public int Team { get; set; }
        public int BaseWords { get; set; }
        public int QAIssuesTotal { get; set; }
        public object QAIssues { get; set; } // TODO
        public IEnumerable<LanguageStatistics> Languages { get; set; }
    }
}
