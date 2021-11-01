using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class File
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        [JsonPropertyName("key_count")]
        public int KeyCount { get; set; }

        public override string ToString()
        {
            return Filename;
        }
    }
}
