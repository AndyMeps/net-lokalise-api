using Lokalise.Api.Collections.Branches;
using Lokalise.Api.Collections.Files;
using Lokalise.Api.Collections.Projects;

namespace Lokalise.Api
{
    public interface ILokaliseClient
    {
        public IProjectsCollection Projects { get; }
        public IBranchesCollection Branches { get; }
        public IFilesCollection Files { get; }
    }
}
