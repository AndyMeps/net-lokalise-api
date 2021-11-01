using Lokalise.Api.Clients;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lokalise.Api
{
    public partial class LokaliseClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly FilesClient _filesClient;

        public LokaliseClient(string apiToken, HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Token", apiToken);
            _httpClient.BaseAddress = new Uri("https://api.lokalise.com/api2/");
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            _filesClient = new FilesClient(_httpClient, _jsonSerializerOptions);
        }

        public LokaliseClient(string apiToken) : this(apiToken, null)
        {

        }

        public FilesClient Files => _filesClient;
    }
}
