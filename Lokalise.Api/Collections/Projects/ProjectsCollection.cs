using Lokalise.Api.Collections.Projects.Configurations;
using Lokalise.Api.Collections.Projects.Requests;
using Lokalise.Api.Collections.Projects.Responses;
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

            var result = await PostAsync<CreateProjectRequest, ProjectResponse>(ProjectsUri(), new CreateProjectRequest(name, cfg));
            return new Project(result);
        }

        /// <inheritdoc/>
        public async Task<DeletedProject> DeleteAsync(string projectId)
        {
            var result = await DeleteAsync<DeletedProjectResponse>(ProjectsUri(projectId));

            return new DeletedProject(result);
        }

        /// <inheritdoc/>
        public async Task<ProjectList> ListAsync(Action<ListProjectsConfiguration> options = null)
        {
            var cfg = new ListProjectsConfiguration();
            options?.Invoke(cfg);

            var result = await GetListAsync<ProjectListResponse>($"{ProjectsUri()}{cfg.ToQueryString()}");

            return new ProjectList(result);
        }

        /// <inheritdoc/>
        public async Task<Project> RetrieveAsync(string projectId)
        {
            var result = await GetAsync<ProjectResponse>(ProjectsUri(projectId));

            return new Project(result);
        }

        /// <inheritdoc/>
        public async Task<EmptiedProject> EmptyAsync(string projectId, string branch = null)
        {
            var result = await PutAsync<EmptiedProjectResponse>($"{ProjectsUri(projectId, branch)}/empty");

            return new EmptiedProject(result);
        }

        /// <inheritdoc/>
        public async Task<Project> UpdateAsync(string projectId, string name, Action<UpdateProjectConfiguration> options = null)
        {
            var cfg = new UpdateProjectConfiguration();
            options?.Invoke(cfg);

            var result = await PutAsync<UpdateProjectRequest, ProjectResponse>(ProjectsUri(projectId), new UpdateProjectRequest(name, cfg));

            return new Project(result);
        }

        private string ProjectsUri(string projectId = null, string branchName = null) => $"projects{(projectId != null ? $"/{projectId.IncludeBranchName(branchName)}" : string.Empty)}";
    }
}
