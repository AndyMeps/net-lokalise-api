using Lokalise.Api.Collections.Branches.Configurations;
using Lokalise.Api.Collections.Branches.Requests;
using Lokalise.Api.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Branches
{
    public class BranchesCollection : BaseCollection, IBranchesCollection
    {
        public BranchesCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        /// <inheritdoc/>
        public Task<Branch> CreateAsync(string projectId, string name)
        {
            return PostAsync<CreateBranchRequest, Branch>($"projects/{projectId}/branches", new CreateBranchRequest(name));
        }

        /// <inheritdoc/>
        public Task<DeletedBranch> DeleteAsync(string projectId, long branchId)
        {
            return DeleteAsync<DeletedBranch>($"projects/{projectId}/branches/{branchId}");
        }

        /// <inheritdoc/>
        public Task<BranchList> ListAsync(string projectId, Action<ListBranchesConfiguration> options = null)
        {
            return GetListAsync<BranchList>($"projects/{projectId}/branches");
        }

        /// <inheritdoc/>
        public Task<MergedBranch> MergeAsync(string projectId, long branchId, Action<MergeBranchConfiguration> options = null)
        {
            var cfg = new MergeBranchConfiguration();
            options?.Invoke(cfg);

            return PostAsync<MergeBranchRequest, MergedBranch>($"projects/{projectId}/branches/{branchId}/merge", new MergeBranchRequest(cfg));
        }

        /// <inheritdoc/>
        public Task<Branch> RetrieveAsync(string projectId, long branchId)
        {
            return GetAsync<Branch>($"projects/{projectId}/branches/{branchId}");
        }

        /// <inheritdoc/>
        public Task<Branch> UpdateAsync(string projectId, long branchId, Action<UpdateBranchConfiguration> options = null)
        {
            var cfg = new UpdateBranchConfiguration();
            options?.Invoke(cfg);

            return PostAsync<UpdateBranchRequest, Branch>($"projects/{projectId}/branches/{branchId}", new UpdateBranchRequest(cfg));
        }
    }
}
