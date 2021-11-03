using Lokalise.Api.Collections.Branches.Configurations;
using Lokalise.Api.Collections.Branches.Requests;
using Lokalise.Api.Collections.Branches.Responses;
using Lokalise.Api.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
            var result = await PostAsync<CreateBranchRequest, BranchResponse>(requestUri, new CreateBranchRequest(name));

            return new Branch(result);
        }

        /// <inheritdoc/>
        public async Task<DeletedBranch> DeleteAsync(string projectId, long branchId)
        {
            var requestUri = BranchUri(projectId, branchId);
            var result = await DeleteAsync<DeletedBranchResponse>(requestUri);

            return new DeletedBranch(result);
        }

        /// <inheritdoc/>
        public async Task<BranchList> ListAsync(string projectId, Action<ListBranchesConfiguration> options = null)
        {
            var requestUri = BranchUri(projectId);
            var result = await GetListAsync<BranchListResponse>(requestUri);

            return new BranchList(result);
        }

        /// <inheritdoc/>
        public async Task<MergedBranch> MergeAsync(string projectId, long branchId, Action<MergeBranchConfiguration> options = null)
        {
            var cfg = new MergeBranchConfiguration();
            options?.Invoke(cfg);

            var requestUri = BranchUri(projectId, branchId);
            var result = await PostAsync<MergeBranchRequest, MergedBranchResponse>($"{requestUri}/merge", new MergeBranchRequest(cfg));
            return new MergedBranch(result);
        }

        /// <inheritdoc/>
        public async Task<Branch> RetrieveAsync(string projectId, long branchId)
        {
            var requestUri = BranchUri(projectId, branchId);
            var result = await GetAsync<BranchResponse>(requestUri);

            return new Branch(result);
        }

        /// <inheritdoc/>
        public async Task<Branch> UpdateAsync(string projectId, long branchId, Action<UpdateBranchConfiguration> options = null)
        {
            var cfg = new UpdateBranchConfiguration();
            options?.Invoke(cfg);

            var requestUri = BranchUri(projectId, branchId);
            var result = await PostAsync<UpdateBranchRequest, BranchResponse>(requestUri, new UpdateBranchRequest(cfg));
            return new Branch(result);
        }

        private string BranchUri(string projectId, long? branchId = null) => $"projects/{projectId}/branches{(branchId.HasValue ? $"/{branchId}" : string.Empty)}";
    }
}
