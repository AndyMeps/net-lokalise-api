using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lokalise.Api.Collections.Responses;
using Lokalise.Api.Exceptions;
using Lokalise.Api.Models;

namespace Lokalise.Api.Collections
{
    internal abstract class BaseCollection
    {
        protected HttpClient HttpClient;
        protected JsonSerializerOptions JsonSerializerOptions;

        internal BaseCollection(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            HttpClient = httpClient;
            JsonSerializerOptions = jsonSerializerOptions;
        }

        protected async Task<TResult?> GetAsync<TResult>(string requestUri)
        {
            var result = await HttpClient.GetAsync(requestUri);

            if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                return default;

            await HandleFailureResponse(result);

            var json = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResult?>(json);
        }

        protected async Task<TResult?> PostAsync<TRequest, TResult>(string requestUri, TRequest request)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(request, JsonSerializerOptions), Encoding.UTF8, "application/json")
            };
            var result = await HttpClient.SendAsync(requestMessage);

            await HandleFailureResponse(result);

            var json = await result.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<TResult?>(json);

            if (model is LocationEntity locationEntityResponse)
            {
                locationEntityResponse.Location = result.Headers.Contains("Location")
                    ? result.Headers.GetValues("Location").FirstOrDefault()
                    : null;
            }

            if (model is PagedList pagedListModel)
            {
                pagedListModel.PageCount = GetHeaderAsIntOrDefault(result.Headers, "X-Pagination-Page-Count");
                pagedListModel.TotalCount = GetHeaderAsIntOrDefault(result.Headers, "X-Pagination-Total-Count");
                pagedListModel.Page = GetHeaderAsIntOrDefault(result.Headers, "X-Pagination-Page");
            }

            return model;
        }

        protected Task<TResult?> PutAsync<TResult>(string requestUri)
        {
            return PutAsync<object, TResult>(requestUri);
        }

        protected async Task<TResult?> PutAsync<TRequest, TResult>(string requestUri, TRequest? request = null) where TRequest : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri);

            if (request != null)
            {
                var requestJson = JsonSerializer.Serialize(request, JsonSerializerOptions);
                requestMessage.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            }

            var result = await HttpClient.SendAsync(requestMessage);

            await HandleFailureResponse(result);

            var responseJson = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResult?>(responseJson);
        }

        protected async Task<TResult?> GetListAsync<TResult>(string requestUri) where TResult : PagedList
        {
            var result = await HttpClient.GetAsync(requestUri);

            await HandleFailureResponse(result);

            var json = await result.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<TResult>(json);

            if (model is null)
                return null;

            model.PageCount = GetHeaderAsIntOrDefault(result.Headers, "X-Pagination-Page-Count");
            model.TotalCount = GetHeaderAsIntOrDefault(result.Headers, "X-Pagination-Total-Count");
            model.Page = GetHeaderAsIntOrDefault(result.Headers, "X-Pagination-Page");

            return model;
        }

        protected async Task<TResult?> DeleteAsync<TResult>(string requestUri)
        {
            var result = await HttpClient.DeleteAsync(requestUri);

            if (result.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                throw new LokaliseRateLimitException(result);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResult?>(json);
        }

        protected async Task<TResult?> DeleteAsync<TRequest, TResult>(string requestUri, TRequest? request = null) where TRequest : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri);

            if (request != null)
            {
                var requestJson = JsonSerializer.Serialize(request, JsonSerializerOptions);
                requestMessage.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            }

            var result = await HttpClient.SendAsync(requestMessage);

            await HandleFailureResponse(result);

            var responseJson = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResult?>(responseJson);
        }

        private static int GetHeaderAsIntOrDefault(HttpResponseHeaders headers, string keyName, int fallbackValue = 0)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));
            if (keyName == null) throw new ArgumentNullException(nameof(keyName));

            if (!headers.TryGetValues(keyName, out var keyValues))
                return fallbackValue;

            return int.TryParse(keyValues?.FirstOrDefault(), out var keyValue)
                ? keyValue
                : fallbackValue;
        }

        private LokaliseError GetLokaliseError(string json)
        {
            var response = JsonSerializer.Deserialize<LokaliseErrorResponse>(json);
            if (response?.Error is null)
                throw new InvalidOperationException($"Attempt to deserialize error response returned null.\nRaw string content:\n{json}");

            return response.Error;
        }

        private async Task HandleFailureResponse(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
                return;

            switch (responseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        var lokaliseError = GetLokaliseError(await responseMessage.Content.ReadAsStringAsync());
                        throw new LokaliseApiException(lokaliseError);
                    }
                case System.Net.HttpStatusCode.TooManyRequests:
                    throw new LokaliseRateLimitException(responseMessage);
                case System.Net.HttpStatusCode.NotAcceptable:
                    {
                        if (responseMessage.RequestMessage?.RequestUri?.Segments?.LastOrDefault() == "download")
                            throw new LokaliseDownloadException(responseMessage);

                        responseMessage.EnsureSuccessStatusCode();
                        break;
                    }
                default:
                    responseMessage.EnsureSuccessStatusCode();
                    break;
            }
        }
    }
}
