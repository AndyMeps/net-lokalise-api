using System.Collections.Specialized;
using Lokalise.Api.Configurations;
using Lokalise.Api.Extensions;

namespace Lokalise.Api.Collections.Projects.Configurations
{
    public class ListProjectsConfiguration : PagedConfiguration
    {
        public long? FilterTeamId { get; set; }
        public string FilterNames { get; set; }
        public bool? IncludeStatistics { get; set; }
        public bool? IncludeSettings { get; set; }

        internal override string ToQueryString()
        {
            var nameValueCollection = new NameValueCollection();

            AddPagedQueryStringParameters(nameValueCollection);

            if (FilterTeamId.HasValue)
                nameValueCollection.Add("filter_team_id", FilterTeamId.ToString());
            if (!string.IsNullOrWhiteSpace(FilterNames))
                nameValueCollection.Add("filter_names", FilterNames);
            if (IncludeStatistics.HasValue)
                nameValueCollection.Add("include_statistics", IncludeStatistics.Value ? "1" : "0");
            if (IncludeSettings.HasValue)
                nameValueCollection.Add("include_settings", IncludeSettings.Value ? "1" : "0");

            var queryString = nameValueCollection.ToQueryString();
            if (queryString == string.Empty)
                return string.Empty;

            return $"?{queryString}";
        }

        internal ListProjectsConfiguration() { }
    }
}