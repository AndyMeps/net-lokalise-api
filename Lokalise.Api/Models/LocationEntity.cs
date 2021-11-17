using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    /// <summary>
    /// Base class used to include Location paths
    /// </summary>
    public abstract class LocationEntity
    {
        [JsonIgnore]
        public string? Location { get; set; }
    }
}