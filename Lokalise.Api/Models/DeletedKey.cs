using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class DeletedKey
    {
        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("key_removed")]
        public bool? KeyRemoved { get; set; }

        [JsonPropertyName("keys_locked")]
        public int? KeysLocked { get; set; }
    }
}
