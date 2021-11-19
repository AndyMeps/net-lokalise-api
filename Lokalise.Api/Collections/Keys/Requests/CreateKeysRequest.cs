using Lokalise.Api.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Keys.Requests
{
    internal class CreateKeysRequest
    {
        [JsonPropertyName("keys")]
        public IEnumerable<NewKey>? Keys { get; }

        [JsonPropertyName("use_automations")]
        public bool? UseAutomations { get; }

        public CreateKeysRequest(IEnumerable<NewKey> keys, bool? useAutomations = null)
        {
            Keys = keys;
            UseAutomations = useAutomations;
        }
    }
}
