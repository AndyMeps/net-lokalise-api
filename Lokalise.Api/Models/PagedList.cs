using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    /// <summary>
    /// Base class used to include pagination information
    /// </summary>
    public abstract class PagedList
    {
        [JsonIgnore]
        public int TotalCount { get; internal set; }

        [JsonIgnore]
        public int PageCount { get; internal set; }
        public int Page { get; internal set; }
    }
}
