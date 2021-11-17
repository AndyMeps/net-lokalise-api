using Lokalise.Api.Collections.Branches.Configurations;
using Lokalise.Api.Collections.Branches.Requests;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Lokalise.Api.Models;

namespace Lokalise.Api.Collections.Branches
{
    internal class BranchesCollection : BaseCollection, IBranchesCollection
    {
        public BranchesCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        /// <inheritdoc/>
        public async Task<Branch> CreateAsync(string projectId, string name)
        {
            var requestUri = BranchUri(projectId);
            var result = await PostAsync<CreateBranchRequest, Branch>(requestUri, new CreateBranchRequest(name));

            return result;
        }

        /// <inheritdoc/>
        public async Task<DeletedBranch> DeleteAsync(string projectId, long branchId)
        {
            var requestUri = BranchUri(projectId, branchId);
            var result = await DeleteAsync<DeletedBranch>(requestUri);

            return result;
        }

        /// <inheritdoc/>
        public async Task<BranchList> ListAsync(string projectId, Action<ListBranchesConfiguration> options = null)
        {
            var requestUri = BranchUri(projectId);
            var result = await GetListAsync<BranchList>(requestUri);

            return result;
        }

        /// <inheritdoc/>
        public async Task<MergedBranch> MergeAsync(string projectId, long branchId, Action<MergeBranchConfiguration> options = null)
        {
            var cfg = new MergeBranchConfiguration();
            options?.Invoke(cfg);

            var requestUri = BranchUri(projectId, branchId);
            var result = await PostAsync<MergeBranchRequest, MergedBranch>($"{requestUri}/merge", new MergeBranchRequest(cfg));
            return result;
        }

        /// <inheritdoc/>
        public async Task<Branch> RetrieveAsync(string projectId, long branchId)
        {
            var requestUri = BranchUri(projectId, branchId);
            var result = await GetAsync<Branch>(requestUri);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Branch> UpdateAsync(string projectId, long branchId, Action<UpdateBranchConfiguration> options = null)
        {
            var cfg = new UpdateBranchConfiguration();
            options?.Invoke(cfg);

            var requestUri = BranchUri(projectId, branchId);
            var result = await PostAsync<UpdateBranchRequest, Branch>(requestUri, new UpdateBranchRequest(cfg));
            return result;
        }

        private string BranchUri(string projectId, long? branchId = null) => $"projects/{projectId}/branches{(branchId.HasValue ? $"/{branchId}" : string.Empty)}";
    }
}
