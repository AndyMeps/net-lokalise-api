using System.Collections.Specialized;
using Lokalise.Api.Extensions;

namespace Lokalise.Api.Clients.Options
{
    public class ListFilesOptions : PagedOptions
    {
        public string FilterFilename { get; set; }

        public string Branch { get; set; }

        internal string ToQueryString()
        {
            var nameValueCollection = new NameValueCollection();

            AddPagedQueryStringParameters(nameValueCollection);

            if (!string.IsNullOrWhiteSpace(FilterFilename))
                nameValueCollection.Add("filter_filename", FilterFilename);

            var queryString = nameValueCollection.ToQueryString();
            if (queryString == string.Empty)
                return string.Empty;

            return $"?{queryString}";
        }
    }
}
