using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class DeletedKeys
    {
        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("keys_removed")]
        public bool? KeysRemoved { get; set; }

        [JsonPropertyName("keys_locked")]
        public long? KeysLocked { get; set; }
    }
}
