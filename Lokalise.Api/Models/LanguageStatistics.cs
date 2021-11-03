using Lokalise.Api.Collections.Projects.Responses;

namespace Lokalise.Api.Models
{
    public class LanguageStatistics
    {
        public long LanguageId { get; }

        public string LanguageIso { get; }

        public long Progress { get; }

        public long WordsToDo { get; }

        public override string ToString()
        {
            return LanguageIso;
        }

        internal LanguageStatistics(LanguageStatisticsResponse response)
        {
            LanguageId = response.LanguageId;
            LanguageIso = response.LanguageIso;
            Progress = response.Progress;
            WordsToDo = response.WordsToDo;
        }
    }
}
