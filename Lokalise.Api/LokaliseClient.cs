using Lokalise.Api.Clients;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lokalise.Api
{
    public class LokaliseClient : ILokaliseClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private IFilesClient _filesClient;
        private IProjectsClient _projectsClient;

        public LokaliseClient(string apiToken, HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Token", apiToken);
            _httpClient.BaseAddress = new Uri("https://api.lokalise.com/api2/");
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        public LokaliseClient(string apiToken) : this(apiToken, null)
        {

        }

        public IFilesClient Files => _filesClient ??= new FilesClient(_httpClient, _jsonSerializerOptions);

        public IProjectsClient Projects => _projectsClient ??= new ProjectsClient(_httpClient, _jsonSerializerOptions);
    }
}
