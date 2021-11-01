using System.Collections.Specialized;

namespace Lokalise.Api.Clients
{
    public abstract class PagedOptions
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
    }
}