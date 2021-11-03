using System.Text.Json.Serialization;

namespace Lokalise.Api.Responses
{
    /// <summary>
    /// Base class used to include Location paths
    /// </summary>
    internal abstract class LocationEntityResponse
    {
        [JsonIgnore]
        public string Location { get; set; }
    }
}