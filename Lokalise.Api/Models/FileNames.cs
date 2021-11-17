using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class FileNames
    {
        [JsonPropertyName("ios")]
#pragma warning disable IDE1006 // Name
        // ReSharper disable once InconsistentNaming
        public string iOS { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        [JsonPropertyName("android")]
        public string Android { get; set; }

        [JsonPropertyName("web")]
        public string Web { get; set; }

        [JsonPropertyName("other")]
        public string Other { get; set; }
    }
}
