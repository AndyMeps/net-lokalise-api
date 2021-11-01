using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public abstract class LocationResult
    {
        [JsonIgnore]
        public string Location { get; internal set; }

        public override string ToString()
        {
            return Location;
        }
    }
}