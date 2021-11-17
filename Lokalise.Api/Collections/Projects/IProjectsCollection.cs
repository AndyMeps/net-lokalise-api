using Lokalise.Api.Collections.Projects.Configurations;
using Lokalise.Api.Models;
using System;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Projects
{
    public interface IProjectsCollection
    {
        /// <summary>
        /// Retrieves a list of projects available to the user.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<ProjectList?> ListAsync(Action<ListProjectsConfiguration>? options = null);

        /// <summary>
        /// <para>Creates a new project in the specified team. Requires Admin role in the team.</para>
        /// <para>Requires write_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Project?> CreateAsync(string name, Action<CreateProjectConfiguration>? options = null);

        /// <summary>
        /// <para>Retrieves a Project object.</para>
        /// <para>Requires read_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public Task<Project?> RetrieveAsync(string projectId);

        /// <summary>
        /// <para>Updates the details of a project. Requires Manage settings admin right.</para>
        /// <para>Requires write_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="name"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Project?> UpdateAsync(string projectId, string name, Action<UpdateProjectConfiguration>? options = null);

        /// <summary>
        /// <para>Deletes all keys and translations from the project. Requires Manage settings admin right.</para>
        /// <para>Requires write_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="branch"></param>
        /// <returns></returns>
        public Task<EmptiedProject?> EmptyAsync(string projectId, string? branch = null);

        /// <summary>
        /// <para>Deletes a project.</para>
        /// <para>Requires write_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public Task<DeletedProject?> DeleteAsync(string projectId);
    }
}
