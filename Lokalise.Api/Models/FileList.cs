using Lokalise.Api.Collections.Files.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Lokalise.Api.Models
{
    public class FileList : PagedList
    {
        public string ProjectId { get; }

        public IEnumerable<File> Files { get; }

        internal FileList(FileListResponse response)
        {
            TotalCount = response.TotalCount;
            PageCount = response.PageCount;
            ProjectId = response.ProjectId;
            Files = response.Files is object ? response.Files.Select(f => new File(f)) : null;
        }
    }
}
