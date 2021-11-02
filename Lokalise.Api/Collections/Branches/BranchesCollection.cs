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
            var requestUri = BranchUri(projectId);
            return PostAsync<CreateBranchRequest, Branch>(requestUri, new CreateBranchRequest(name));
        }

        /// <inheritdoc/>
        public Task<DeletedBranch> DeleteAsync(string projectId, long branchId)
        {
            var requestUri = BranchUri(projectId, branchId);
            return DeleteAsync<DeletedBranch>(requestUri);
        }

        /// <inheritdoc/>
        public Task<BranchList> ListAsync(string projectId, Action<ListBranchesConfiguration> options = null)
        {
            var requestUri = BranchUri(projectId);
            return GetListAsync<BranchList>(requestUri);
        }

        /// <inheritdoc/>
        public Task<MergedBranch> MergeAsync(string projectId, long branchId, Action<MergeBranchConfiguration> options = null)
        {
            var cfg = new MergeBranchConfiguration();
            options?.Invoke(cfg);

            var requestUri = BranchUri(projectId, branchId);
            return PostAsync<MergeBranchRequest, MergedBranch>($"{requestUri}/merge", new MergeBranchRequest(cfg));
        }

        /// <inheritdoc/>
        public Task<Branch> RetrieveAsync(string projectId, long branchId)
        {
            var requestUri = BranchUri(projectId, branchId);
            return GetAsync<Branch>(requestUri);
        }

        /// <inheritdoc/>
        public Task<Branch> UpdateAsync(string projectId, long branchId, Action<UpdateBranchConfiguration> options = null)
        {
            var cfg = new UpdateBranchConfiguration();
            options?.Invoke(cfg);

            var requestUri = BranchUri(projectId, branchId);
            return PostAsync<UpdateBranchRequest, Branch>(requestUri, new UpdateBranchRequest(cfg));
        }

        private string BranchUri(string projectId, long? branchId = null) => $"projects/{projectId}/branches{(branchId.HasValue ? $"/{branchId}" : string.Empty)}";
    }
}
