using System.Collections.Specialized;
using Lokalise.Api.Extensions;

namespace Lokalise.Api.Clients.Options
{
    public class ListFilesOptions
    {
        public string FilterFilename { get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public string Branch { get; set; }

        internal string ToQueryString()
        {
            var nameValueCollecton = new NameValueCollection();
            if (Page.HasValue)
                nameValueCollecton.Add("page", Page.ToString());
            if (Limit.HasValue)
                nameValueCollecton.Add("limit", Limit.ToString());
            if (!string.IsNullOrWhiteSpace(FilterFilename))
                nameValueCollecton.Add("filter_filename", FilterFilename);

            var queryString = nameValueCollecton.ToQueryString();
            if (queryString == string.Empty)
                return string.Empty;

            return $"?{queryString}";
        }
    }
}
