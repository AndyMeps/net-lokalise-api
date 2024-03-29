﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lokalise.Api.Models
{
    public class FileList : PagedList
    {
        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("files")]
        public IEnumerable<File>? Files { get; set; }
    }
}
