using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class BranchList : ListResult
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("branches")]
        public IEnumerable<Branch> Branches { get; set; }
    }
}
