using System.Text.Json.Serialization;

namespace Lokalise.Api.Responses
{
    /// <summary>
    /// Base class used to include pagination information
    /// </summary>
    internal abstract class PagedListResponse
    {
        [JsonIgnore]
        public int TotalCount { get; internal set; }

        [JsonIgnore]
        public int PageCount { get; internal set; }
    }
}
