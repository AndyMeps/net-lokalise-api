using Lokalise.Api.Collections.Branches.Configurations;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Collections.Branches.Requests
{
    internal class UpdateBranchRequest
    {
        [JsonPropertyName("name")]
        public string? Name { get; }

        internal UpdateBranchRequest(UpdateBranchConfiguration options)
        {
            Name = options.Name;
        }
    }
}
