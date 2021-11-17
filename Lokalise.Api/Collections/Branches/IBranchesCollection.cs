using Lokalise.Api.Collections.Branches.Configurations;
using System;
using System.Threading.Tasks;
using Lokalise.Api.Models;

namespace Lokalise.Api.Collections.Branches
{
    public interface IBranchesCollection
    {
        /// <summary>
        /// <para>Retrieves a list of branches.</para>
        /// <para>Requires read_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<BranchList> ListAsync(string projectId, Action<ListBranchesConfiguration> options = null);

        /// <summary>
        /// <para>Retrieves a Branch object.</para>
        /// <para>Requires read_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Task<Branch> RetrieveAsync(string projectId, long branchId);

        /// <summary>
        /// <para>Creates a branch in the project. Requires admin right.</para>
        /// <para>Requires write_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Branch> CreateAsync(string projectId, string name);

        /// <summary>
        /// <para>Updates a branch in the project. Requires admin right.</para>
        /// <para>Requires write_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="branchId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<Branch> UpdateAsync(string projectId, long branchId, Action<UpdateBranchConfiguration> options = null);

        /// <summary>
        /// <para>Deletes a configured branch in the project. Requires admin right.</para>
        /// <para>Requires write_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Task<DeletedBranch> DeleteAsync(string projectId, long branchId);

        /// <summary>
        /// <para>Merges a branch in the project. Requires admin right.</para>
        /// <para>Requires write_projects OAuth access scope.</para>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="branchId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<MergedBranch> MergeAsync(string projectId, long branchId, Action<MergeBranchConfiguration> options = null);
    }
}