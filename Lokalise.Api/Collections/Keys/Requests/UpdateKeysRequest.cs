using Lokalise.Api.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Keys.Requests
{
    internal class UpdateKeysRequest
    {
        [JsonPropertyName("keys")]
        public IEnumerable<UpdateKey> Keys { get; }

        public UpdateKeysRequest(IEnumerable<UpdateKey> keys)
        {
            Keys = keys;
        }
    }
}
