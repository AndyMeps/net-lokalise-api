using Lokalise.Api.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Requests
{
    internal class CreateContributorsRequest
    {
        [JsonPropertyName("contributors")]
        public IEnumerable<NewContributor> Contributors { get; set; }

        internal CreateContributorsRequest(IEnumerable<NewContributor> newContributors)
        {
            Contributors = newContributors;
        }
    }
}
