using Lokalise.Api.Collections.Keys.Configurations;
using Lokalise.Api.Collections.Keys.Requests;
using Lokalise.Api.Extensions;
using Lokalise.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Keys
{
    internal class KeysCollection : BaseCollection, IKeysCollection
    {
        internal KeysCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions) : base(httpClient, jsonSerializerOptions)
        {
        }

        /// <inheritdoc/>
        public Task<KeyList?> CreateAsync(
            string projectId,
            NewKey key,
            Action<CreateKeysConfiguration>? options = null)
        {
            return CreateAsync(projectId, new NewKey[] { key }, options);
        }

        /// <inheritdoc/>
        public Task<KeyList?> CreateAsync(
            string projectId,
            IEnumerable<NewKey> keys,
            Action<CreateKeysConfiguration>? options = null)
        {
            var cfg = new CreateKeysConfiguration();
            options?.Invoke(cfg);

            return PostAsync<CreateKeysRequest, KeyList>(KeysUri(projectId.IncludeBranchName(cfg.Branch)), new CreateKeysRequest(keys, cfg.UseAutomations));
        }

        /// <inheritdoc/>
        public async Task<DeletedKey?> DeleteAsync(
            string projectId,
            long keyId,
            Action<DeleteKeyConfiguration>? options = null)
        {
            var cfg = new DeleteKeyConfiguration();
            options?.Invoke(cfg);

            var result = await DeleteAsync<DeletedKey>(KeysUri(projectId.IncludeBranchName(cfg.Branch), keyId));

            return result;
        }

        public async Task<DeletedKeys?> DeleteAsync(string projectId, IEnumerable<long> keyIds, Action<DeleteKeyConfiguration>? options = null)
        {
            var cfg = new DeleteKeyConfiguration();
            options?.Invoke(cfg);

            var request = new DeleteKeysRequest(keyIds);
            var result = await DeleteAsync<DeleteKeysRequest, DeletedKeys>(KeysUri(projectId.IncludeBranchName(cfg.Branch)), request);

            return result;
        }

        /// <inheritdoc/>
        public async Task<KeyList?> ListAsync(string projectId, Action<ListKeysConfiguration>? options = null)
        {
            var cfg = new ListKeysConfiguration();
            options?.Invoke(cfg);

            var result = await GetListAsync<KeyList>($"{KeysUri(projectId.IncludeBranchName(cfg.Branch))}{cfg.ToQueryString()}");

            return result;
        }

        /// <inheritdoc/>
        public async Task<ProjectKey?> RetrieveAsync(string projectId, long keyId, Action<RetrieveKeyConfiguration>? options = null)
        {
            var cfg = new RetrieveKeyConfiguration();
            options?.Invoke(cfg);

            var result = await GetAsync<ProjectKey>(KeysUri(projectId.IncludeBranchName(cfg.Branch), keyId));

            return result;
        }

        /// <inheritdoc/>
        public async Task<ProjectKey?> UpdateAsync(string projectId, UpdateKey updateKey, string? branch = null)
        {
            var result = await PutAsync<UpdateKey, ProjectKey>(KeysUri(projectId.IncludeBranchName(branch), updateKey.KeyId), updateKey);

            return result;
        }

        /// <inheritdoc/>
        public async Task<KeyList?> UpdateAsync(string projectId, IEnumerable<UpdateKey> updateKeys, string? branch = null)
        {
            var request = new UpdateKeysRequest(updateKeys);

            var result = await PutAsync<UpdateKeysRequest, KeyList>(KeysUri(projectId.IncludeBranchName(branch)), request);

            return result;
        }

        private string KeysUri(string projectId, long? keyId = null)
        {
            var sb = new StringBuilder();
            sb.Append($"projects/{projectId}/keys");

            if (!keyId.HasValue)
                return sb.ToString();

            sb.Append($"/{keyId}");

            return sb.ToString();
        }
    }
}
