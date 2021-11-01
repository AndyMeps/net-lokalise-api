using Lokalise.Api.Clients.Options;
using Lokalise.Api.Clients.Requests;
using Lokalise.Api.Extensions;
using Lokalise.Api.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Clients
{
    public class FilesClient : IFilesClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        internal FilesClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        /// <inheritdoc/>
        public Task<FileList> ListAsync(string projectId, Action<ListFilesOptions> options = null)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project identifier is required to call ListAsync", nameof(projectId));

            return ListInternalAsync(projectId, options);
        }

        /// <inheritdoc />
        public Task<UploadedFile> UploadAsync(string projectId, FileInfo fileInfo, string filename, string langIso, Action<UploadFileOptions> options = null)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (fileInfo is null)
                throw new ArgumentNullException(nameof(fileInfo));

            if (filename is null)
                throw new ArgumentNullException(nameof(filename));

            if (langIso is null)
                throw new ArgumentNullException(nameof(langIso));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project identifier is required to call UploadAsync", nameof(projectId));

            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("Filename is required to call UploadAsync", nameof(filename));

            if (string.IsNullOrWhiteSpace(langIso))
                throw new ArgumentException("Language ISO is required to call UploadAsync", nameof(langIso));

            if (!fileInfo.Exists)
                throw new ArgumentException("File must exist to call UploadAsync", nameof(fileInfo));

            return UploadInternalAsync(projectId, fileInfo.ToBase64(), filename, langIso, options);
        }

        /// <inheritdoc/>
        public Task<UploadedFile> UploadAsync(string projectId, string data, string filename, string langIso, Action<UploadFileOptions> options)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (filename is null)
                throw new ArgumentNullException(nameof(filename));

            if (langIso is null)
                throw new ArgumentNullException(nameof(langIso));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project identifier is required to call UploadAsync", nameof(projectId));

            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("Filename is required to call UploadAsync", nameof(filename));

            if (string.IsNullOrWhiteSpace(langIso))
                throw new ArgumentException("Language ISO is required to call UploadAsync", nameof(langIso));

            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("Data is required to call UploadAsync", nameof(data));

            if (!Convert.TryFromBase64String(data, new Span<byte>(new byte[data.Length]), out var _))
                throw new ArgumentException("Data is not valid base64 content.", nameof(data));

            return UploadInternalAsync(projectId, data, filename, data, options);
        }

        /// <inheritdoc />
        public Task<DownloadedFiles> DownloadAsync(string projectId, string format, Action<DownloadFileOptions> options = null)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (format is null)
                throw new ArgumentNullException(nameof(format));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project identifier is required to call DownloadAsync", nameof(projectId));

            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentException("Format is required to call DownloadAsync", nameof(projectId));

            return DownloadInternalAsync(projectId, format, options);
        }

        private async Task<FileList> ListInternalAsync(string projectId, Action<ListFilesOptions> options = null)
        {
            var cfg = new ListFilesOptions();
            options?.Invoke(cfg);

            var requestUri = $"projects/{projectId.IncludeBranchName(cfg.Branch)}/files{cfg?.ToQueryString()}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var result = await _httpClient.SendAsync(request);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<FileList>(json);
        }

        private async Task<UploadedFile> UploadInternalAsync(string projectId, string data, string filename, string langIso, Action<UploadFileOptions> options = null)
        {
            var cfg = new UploadFileOptions();
            options?.Invoke(cfg);

            var request = new HttpRequestMessage(HttpMethod.Post, $"projects/{projectId.IncludeBranchName(cfg.Branch)}/files/upload")
            {
                Content = new StringContent(
                    content: JsonSerializer.Serialize(new UploadFileRequest(data, filename, langIso, cfg), _jsonSerializerOptions),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            var result = await _httpClient.SendAsync(request);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            var body = JsonSerializer.Deserialize<UploadedFile>(json);
            body.Location = result.Headers.Contains("Location")
                ? result.Headers.GetValues("Location").Single()
                : null;

            return body;
        }

        private async Task<DownloadedFiles> DownloadInternalAsync(string projectId, string format, Action<DownloadFileOptions> options = null)
        {
            var cfg = new DownloadFileOptions();
            options?.Invoke(cfg);

            var request = new HttpRequestMessage(HttpMethod.Post, $"projects/{projectId.IncludeBranchName(cfg.Branch)}/files/download")
            {
                Content = new StringContent(
                    content: JsonSerializer.Serialize(new DownloadFileRequest(format, cfg), _jsonSerializerOptions),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            var result = await _httpClient.SendAsync(request);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var body = JsonSerializer.Deserialize<DownloadedFiles>(json);

            return body;
        }
    }
}
