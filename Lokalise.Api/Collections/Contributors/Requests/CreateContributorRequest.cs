using Lokalise.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Contributors.Requests
{
    internal class CreateContributorsRequest
    {
        [JsonPropertyName("contributors")]
        public IEnumerable<NewContributorDto> Contributors { get; set; }

        internal CreateContributorsRequest(IEnumerable<NewContributor> newContributors)
        {
            Contributors = newContributors is object ? newContributors.Select(c => new NewContributorDto(c)) : null;
        }
    }
}
