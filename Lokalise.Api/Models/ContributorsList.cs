using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class ContributorsList : PagedList
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("contributors")]
        public IEnumerable<Contributor> Contributors { get; set; }
    }
}
