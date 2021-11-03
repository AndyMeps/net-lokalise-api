namespace Lokalise.Api.Models
{
    public abstract class PagedList
    {
        public long PageCount { get; protected set; }
        public long TotalCount { get; protected set; }
    }
}
