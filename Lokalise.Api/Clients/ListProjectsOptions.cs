using System.Collections.Specialized;
using Lokalise.Api.Extensions;

namespace Lokalise.Api.Clients
{
    public class ListProjectsOptions
    {
        public long? FilterTeamId { get; set; }
        public string FilterNames { get; set; }
        public bool? IncludeStatistics { get; set; }
        public bool? IncludeSettings { get; set; }
        public int? Limit { get; set; }
        public int? Page { get; set; }

        public string ToQueryString()
        {
            var nameValueCollecton = new NameValueCollection();

            if (Page.HasValue)
                nameValueCollecton.Add("page", Page.ToString());
            if (Limit.HasValue)
                nameValueCollecton.Add("limit", Limit.ToString());
            if (FilterTeamId.HasValue)
                nameValueCollecton.Add("filter_team_id", FilterTeamId.ToString());
            if (!string.IsNullOrWhiteSpace(FilterNames))
                nameValueCollecton.Add("filter_names", FilterNames);
            if (IncludeStatistics.HasValue)
                nameValueCollecton.Add("include_statistics", IncludeStatistics.Value ? "1" : "0");
            if (IncludeSettings.HasValue)
                nameValueCollecton.Add("include_settings", IncludeSettings.Value ? "1" : "0");

            var queryString = nameValueCollecton.ToQueryString();
            if (queryString == string.Empty)
                return string.Empty;

            return $"?{queryString}";
        }
    }
}