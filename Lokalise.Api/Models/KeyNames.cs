using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class KeyNames
    {
        [JsonPropertyName("ios")]
#pragma warning disable IDE1006 // Naming Styles
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
