using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    internal class Contributors
    {
        [JsonPropertyName("contributors")]
        public IEnumerable<Contributor> Data { get; set; }
    }
}
