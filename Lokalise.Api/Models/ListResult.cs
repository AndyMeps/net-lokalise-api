using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public abstract class ListResult
    {
        [JsonIgnore]
        public int TotalCount { get; internal set; }

        [JsonIgnore]
        public int PageCount { get; internal set; }
    }
}
