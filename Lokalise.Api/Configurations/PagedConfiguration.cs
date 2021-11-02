using Lokalise.Api.Extensions;
using System.Collections.Specialized;

namespace Lokalise.Api.Configurations
{
    public abstract class PagedConfiguration
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }

        protected void AddPagedQueryStringParameters(NameValueCollection nameValueCollection)
        {
            if (Page.HasValue)
                nameValueCollection.Add("page", Page.ToString());
            if (Limit.HasValue)
                nameValueCollection.Add("limit", Limit.ToString());
        }

        internal virtual string ToQueryString()
        {
            var nameValueCollection = new NameValueCollection();

            AddPagedQueryStringParameters(nameValueCollection);

            var queryString = nameValueCollection.ToQueryString();
            if (queryString == string.Empty)
                return string.Empty;

            return $"?{queryString}";
        }
    }
}