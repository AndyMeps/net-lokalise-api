using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Keys.Requests
{
    internal class DeleteKeysRequest
    {
        [JsonPropertyName("keys")]
        public IEnumerable<long> Keys { get; set; }

        public DeleteKeysRequest(IEnumerable<long> keys)
        {
            Keys = keys;
        }
    }
}
