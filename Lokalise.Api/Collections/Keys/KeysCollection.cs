using Lokalise.Api.Collections.Keys.Configurations;
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

        public Task<KeyList> CreateAsync(
            string projectId,
            NewKey key,
            Action<CreateKeysConfiguration> options = null)
        {
            throw new NotImplementedException();
        }

        public Task<KeyList> CreateAsync(
            string projectId,
            IEnumerable<NewKey> keys,
            Action<CreateKeysConfiguration> options = null)
        {
            throw new NotImplementedException();
        }

        public async Task<DeletedKey> DeleteAsync(
            string projectId,
            long keyId,
            Action<DeleteKeyConfiguration> options = null)
        {
            var cfg = new DeleteKeyConfiguration();
            options?.Invoke(cfg);

            var result = await DeleteAsync<DeletedKey>(KeysUri(projectId.IncludeBranchName(cfg.Branch), keyId));

            return result;
        }

        public async Task<KeyList> ListAsync(string projectId, Action<ListKeysConfiguration> options = null)
        {
            var cfg = new ListKeysConfiguration();
            options?.Invoke(cfg);

            var result = await GetListAsync<KeyList>(KeysUri(projectId.IncludeBranchName(cfg.Branch)));

            return result;
        }

        public async Task<ProjectKey> RetrieveAsync(string projectId, long keyId, Action<RetrieveKeyConfiguration> options = null)
        {
            var cfg = new RetrieveKeyConfiguration();
            options?.Invoke(cfg);

            var result = await GetAsync<ProjectKey>(KeysUri(projectId.IncludeBranchName(cfg.Branch), keyId));

            return result;
        }

        public Task<ProjectKey> UpdateAsync(string projectId, long keyId, Action<UpdateKeyConfiguration> options = null)
        {
            throw new NotImplementedException();
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
