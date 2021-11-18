using Lokalise.Api.Collections.Contributors.Configurations;
using Lokalise.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Contributors
{
    public interface IContributorsCollection
    {
        Task<ContributorsList?> ListAsync(string projectId, Action<ListContributorsConfiguration>? options = null);

        Task<Contributor?> CreateAsync(string projectId, NewContributor newContributor, Action<CreateContributorConfiguration>? options = null);

        Task<IEnumerable<Contributor>> CreateAsync(string projectId, IEnumerable<NewContributor> contributors, Action<CreateContributorConfiguration>? options = null);

        Task<ProjectContributor?> RetrieveAsync(string projectId, long contributorId, Action<RetrieveContributorConfiguration>? options = null);

        Task<ProjectContributor?> UpdateAsync(string projectId, long contributorId, Action<UpdateContributorConfiguration>? options = null);

        Task<DeletedContributor?> DeleteAsync(string projectId, long contributorId);
    }
}
