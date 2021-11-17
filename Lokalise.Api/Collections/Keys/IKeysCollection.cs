using Lokalise.Api.Collections.Keys.Configurations;
using Lokalise.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Keys
{
    public interface IKeysCollection
    {
        Task<KeyList> ListAsync(string projectId, Action<ListKeysConfiguration> options = null);

        Task<KeyList> CreateAsync(string projectId, NewKey key, Action<CreateKeysConfiguration> options = null);

        Task<KeyList> CreateAsync(string projectId, IEnumerable<NewKey> keys, Action<CreateKeysConfiguration> options = null);

        Task<ProjectKey> RetrieveAsync(string projectId, long keyId, Action<RetrieveKeyConfiguration> options = null);

        Task<ProjectKey> UpdateAsync(string projectId, long keyId, Action<UpdateKeyConfiguration> options = null);

        Task<DeletedKey> DeleteAsync(string projectId, long keyId, Action<DeleteKeyConfiguration> options = null);
    }
}
