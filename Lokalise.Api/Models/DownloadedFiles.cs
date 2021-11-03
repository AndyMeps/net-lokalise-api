using Lokalise.Api.Collections.Files.Responses;

namespace Lokalise.Api.Models
{
    public class DownloadedFiles
    {
        public string ProjectId { get; }

        public string BundleUrl { get; }

        internal DownloadedFiles(DownloadedFilesResponse response)
        {
            ProjectId = response.ProjectId;
            BundleUrl = response.BundleUrl;
        }
    }
}