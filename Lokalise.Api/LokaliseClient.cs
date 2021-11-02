using Lokalise.Api.Collections.Branches;
using Lokalise.Api.Collections.Files;
using Lokalise.Api.Collections.Projects;
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
        private IFilesCollection _filesClient;
        private IProjectsCollection _projectsClient;
        private IBranchesCollection _branchesClient;

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

        public IFilesCollection Files => _filesClient ??= new FilesCollection(_httpClient, _jsonSerializerOptions);

        public IProjectsCollection Projects => _projectsClient ??= new ProjectsCollection(_httpClient, _jsonSerializerOptions);

        public IBranchesCollection Branches => _branchesClient ??= new BranchesCollection(_httpClient, _jsonSerializerOptions);
    }
}
