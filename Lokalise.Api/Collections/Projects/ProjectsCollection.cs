using Lokalise.Api.Collections.Projects.Configurations;
using Lokalise.Api.Collections.Projects.Requests;
using Lokalise.Api.Extensions;
using Lokalise.Api.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Projects
{
    internal class ProjectsCollection : BaseCollection, IProjectsCollection
    {
        internal ProjectsCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        /// <inheritdoc/>
        public async Task<Project> CreateAsync(string name, Action<CreateProjectConfiguration> options = null)
        {
            var cfg = new CreateProjectConfiguration();
            options?.Invoke(cfg);

            var result = await PostAsync<CreateProject, Project>(ProjectsUri(), new CreateProject(name, cfg));
            return result;
        }

        /// <inheritdoc/>
        public async Task<DeletedProject> DeleteAsync(string projectId)
        {
            var result = await DeleteAsync<DeletedProject>(ProjectsUri(projectId));

            return result;
        }

        /// <inheritdoc/>
        public async Task<ProjectList> ListAsync(Action<ListProjectsConfiguration> options = null)
        {
            var cfg = new ListProjectsConfiguration();
            options?.Invoke(cfg);

            var result = await GetListAsync<ProjectList>($"{ProjectsUri()}{cfg.ToQueryString()}");

            return result;
        }

        /// <inheritdoc/>
        public async Task<Project> RetrieveAsync(string projectId)
        {
            var result = await GetAsync<Project>(ProjectsUri(projectId));

            return result;
        }

        /// <inheritdoc/>
        public async Task<EmptiedProject> EmptyAsync(string projectId, string branch = null)
        {
            var result = await PutAsync<EmptiedProject>($"{ProjectsUri(projectId, branch)}/empty");

            return result;
        }

        /// <inheritdoc/>
        public async Task<Project> UpdateAsync(string projectId, string name, Action<UpdateProjectConfiguration> options = null)
        {
            var cfg = new UpdateProjectConfiguration();
            options?.Invoke(cfg);

            var result = await PutAsync<UpdateProject, Project>(ProjectsUri(projectId), new UpdateProject(name, cfg));

            return result;
        }

        private string ProjectsUri(string projectId = null, string branchName = null) => $"projects{(projectId != null ? $"/{projectId.IncludeBranchName(branchName)}" : string.Empty)}";
    }
}
