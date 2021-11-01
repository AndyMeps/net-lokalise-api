using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Lokalise.Api.Models;

namespace Lokalise.Api.Clients
{
    public class ProjectsClient : IProjectsClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        internal ProjectsClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        public async Task<ProjectList> ListAsync(Action<ListProjectsOptions> options = null)
        {
            var cfg = new ListProjectsOptions();
            options?.Invoke(cfg);

            var requestUri = $"projects{cfg.ToQueryString()}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var result = await _httpClient.SendAsync(request);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ProjectList>(json);
        }
    }
}
