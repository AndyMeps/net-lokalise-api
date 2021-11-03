﻿using Lokalise.Api.Collections.Branches;
using Lokalise.Api.Collections.Comments;
using Lokalise.Api.Collections.Files;
using Lokalise.Api.Collections.Projects;

namespace Lokalise.Api
{
    public interface ILokaliseClient
    {
        public IBranchesCollection Branches { get; }
        public ICommentsCollection Comments { get; }
        public IProjectsCollection Projects { get; }
        public IFilesCollection Files { get; }
    }
}
