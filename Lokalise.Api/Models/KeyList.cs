using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class KeyList : PagedList
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("keys")]
        public IEnumerable<Key> Keys { get; set; }
    }
}
