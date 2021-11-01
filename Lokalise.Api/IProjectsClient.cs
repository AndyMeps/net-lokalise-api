using Lokalise.Api.Clients;
using Lokalise.Api.Models;
using System;
using System.Threading.Tasks;

namespace Lokalise.Api
{
    public interface IProjectsClient
    {
        public Task<ProjectList> ListAsync(Action<ListProjectsOptions> options = null);
    }
}
