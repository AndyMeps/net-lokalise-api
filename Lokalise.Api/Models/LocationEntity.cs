namespace Lokalise.Api.Models
{
    public abstract class LocationEntity
    {
        public string Location { get; internal set; }

        public override string ToString()
        {
            return Location;
        }
    }
}