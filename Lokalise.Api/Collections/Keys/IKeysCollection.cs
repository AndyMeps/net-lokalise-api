using Lokalise.Api.Collections.Keys.Configurations;
using Lokalise.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Keys
{
    public interface IKeysCollection
    {
        /// <summary>
        /// <para>Lists all keys in the project.</para>
        /// <para>IMPORTANT: We do not provide a content delivery network for your language files.<br/>
        /// -- Do not engage a request to this endpoint with every your website/app visitor.<br/>
        /// -- Instead, fetch this endpoint from time to time, store the result locally and serve your visitors with static files/your database content.<br/>
        /// -- Alternatively, you may use our Amazon S3/Google CouldStorage integrations in automatically upload your language files to a bucket of your choice.</para>
        /// </summary>
        Task<KeyList?> ListAsync(string projectId, Action<ListKeysConfiguration>? options = null);

        /// <summary>
        /// <para>Creates one or more keys in the project.</para>
        /// <para>Requires Manage keys admin right. We recommend sending payload in chunks of up to 500 keys per request.</para>
        /// </summary>
        Task<KeyList?> CreateAsync(string projectId, NewKey key, Action<CreateKeysConfiguration>? options = null);

        /// <summary>
        /// <para>Creates one or more keys in the project.</para>
        /// <para>Requires Manage keys admin right. We recommend sending payload in chunks of up to 500 keys per request.</para>
        /// </summary>
        Task<KeyList?> CreateAsync(string projectId, IEnumerable<NewKey> keys, Action<CreateKeysConfiguration>? options = null);

        /// <summary>
        /// <para>Retrieves a Key object.</para>
        /// <para>Requires read_keys OAuth access scope.</para>
        /// </summary>
        Task<ProjectKey?> RetrieveAsync(string projectId, long keyId, Action<RetrieveKeyConfiguration>? options = null);

        /// <summary>
        /// <para>Updates the properties of a key and it’s associated objects. Requires Manage keys admin right.</para>
        /// <para>Requires write_keys OAuth access scope.</para>
        /// </summary>
        Task<ProjectKey?> UpdateAsync(string projectId, long keyId, Action<UpdateKeyConfiguration>? options = null);

        /// <summary>
        /// <para>Updates one or more keys in the project. Requires Manage keys admin right.</para>
        /// <para>Requires write_keys OAuth access scope.</para>
        /// </summary>
        Task<DeletedKey?> DeleteAsync(string projectId, long keyId, Action<DeleteKeyConfiguration>? options = null);
    }
}
