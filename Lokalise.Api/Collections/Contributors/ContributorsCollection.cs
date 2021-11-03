using Lokalise.Api.Collections.Contributors.Configurations;
using Lokalise.Api.Collections.Contributors.Requests;
using Lokalise.Api.Collections.Contributors.Responses;
using Lokalise.Api.Extensions;
using Lokalise.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Contributors
{
    internal class ContributorsCollection : BaseCollection, IContributorsCollection
    {
        public ContributorsCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        private string ContributorsUri(string projectId, long? contributorId = null)
        {
            var sb = new StringBuilder();
            sb.Append($"projects/{projectId}/contributors");

            if (!contributorId.HasValue)
                return sb.ToString();

            sb.Append($"/{contributorId}");

            return sb.ToString();
        }

        public async Task<Contributor> CreateAsync(string projectId, NewContributor newContributor, Action<CreateContributorConfiguration> options = null)
        {
            var result = await CreateAsync(projectId, new NewContributor[] { newContributor }, options);

            return result?.FirstOrDefault();
        }

        public async Task<IEnumerable<Contributor>> CreateAsync(string projectId, IEnumerable<NewContributor> newContributors, Action<CreateContributorConfiguration> options = null)
        {
            var cfg = new CreateContributorConfiguration();
            options?.Invoke(cfg);

            var result = await PostAsync<CreateContributorsRequest, ContributorsResponse>(
                requestUri: ContributorsUri(projectId.IncludeBranchName(cfg.Branch)),
                request: new CreateContributorsRequest(newContributors));

            return result?.Contributors?.Select(c => new Contributor(c));
        }

        public async Task<DeletedContributor> DeleteAsync(string projectId, long contributorId)
        {
            var result = await DeleteAsync<DeletedContributorResponse>(ContributorsUri(projectId, contributorId));

            return new DeletedContributor(result);
        }

        public async Task<ContributorsList> ListAsync(string projectId, Action<ListContributorsConfiguration> options = null)
        {
            var cfg = new ListContributorsConfiguration();
            options?.Invoke(cfg);

            var requestUri = $"{ContributorsUri(projectId.IncludeBranchName(cfg.Branch))}{cfg.ToQueryString()}";
            var result = await GetListAsync<ContributorsListResponse>(requestUri);

            return new ContributorsList(result);
        }

        public async Task<ProjectContributor> RetrieveAsync(string projectId, long contributorId, Action<RetrieveContributorConfiguration> options = null)
        {
            var cfg = new RetrieveContributorConfiguration();
            options?.Invoke(cfg);

            var result = await GetAsync<ProjectContributorResponse>(ContributorsUri(projectId, contributorId));

            return new ProjectContributor(result);
        }

        public async Task<ProjectContributor> UpdateAsync(string projectId, long contributorId, Action<UpdateContributorConfiguration> options = null)
        {
            var cfg = new UpdateContributorConfiguration();
            options?.Invoke(cfg);

            var requestUri = ContributorsUri(projectId.IncludeBranchName(cfg.Branch), contributorId);
            var result = await PutAsync<UpdateContributorRequest, ProjectContributorResponse>(requestUri, new UpdateContributorRequest(cfg));

            return new ProjectContributor(result);
        }
    }
}
