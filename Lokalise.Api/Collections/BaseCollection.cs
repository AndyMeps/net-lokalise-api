using Lokalise.Api.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections
{
    public abstract class BaseCollection
    {
        protected HttpClient HttpClient;
        protected JsonSerializerOptions JsonSerializerOptions;

        internal BaseCollection(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            HttpClient = httpClient;
            JsonSerializerOptions = jsonSerializerOptions;
        }

        protected async Task<TResult> GetAsync<TResult>(string requestUri)
        {
            var result = await HttpClient.GetAsync(requestUri);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResult>(json);
        }

        protected async Task<TResult> PostAsync<TRequest, TResult>(string requestUri, TRequest request)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(request, JsonSerializerOptions), Encoding.UTF8, "application/json")
            };
            var result = await HttpClient.SendAsync(requestMessage);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<TResult>(json);

            if (model is LocationResult locationResultModel)
            {
                locationResultModel.Location = result.Headers.Contains("Location")
                    ? result.Headers.GetValues("Location").FirstOrDefault()
                    : null;
            }

            return model;
        }

        protected Task<TResult> PutAsync<TResult>(string requestUri)
        {
            return PutAsync<object, TResult>(requestUri);
        }

        protected async Task<TResult> PutAsync<TRequest, TResult>(string requestUri, TRequest request = null) where TRequest : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri);

            if (request is object)
            {
                requestMessage.Content = new StringContent(JsonSerializer.Serialize(request, JsonSerializerOptions), Encoding.UTF8, "application/json");
            }

            var result = await HttpClient.SendAsync(requestMessage);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResult>(json);
        }

        protected async Task<TResult> GetListAsync<TResult>(string requestUri) where TResult : ListResult
        {
            var result = await HttpClient.GetAsync(requestUri);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<TResult>(json);

            model.PageCount = result.Headers.Contains("X-Pagination-Page-Count")
                ? int.Parse(result.Headers.GetValues("X-Pagination-Page-Count").FirstOrDefault())
                : 0;

            model.TotalCount = result.Headers.Contains("X-Pagination-Total-Count")
                ? int.Parse(result.Headers.GetValues("X-Pagination-Total-Count").FirstOrDefault())
                : 0;

            return model;
        }

        protected async Task<TResult> DeleteAsync<TResult>(string requestUri)
        {
            var result = await HttpClient.DeleteAsync(requestUri);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResult>(json);
        }
    }
}
